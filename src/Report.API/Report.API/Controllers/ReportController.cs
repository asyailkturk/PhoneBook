using AutoMapper;
using EventBusRabbitMQ.Common;
using EventBusRabbitMQ.Events;
using EventBusRabbitMQ.Producer;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using PhoneBook.API.Repositories.Interfaces;
using Report.API.Entities;
using Report.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Report.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReportController: ControllerBase
    {
        private readonly IReportRepository _repository;
        private readonly IMapper _mapper;
        private readonly EventBusRabbitMQProducer _eventBus;
        private readonly IContactRepository _contactRepository;

        public ReportController(IReportRepository repository, IMapper mapper, EventBusRabbitMQProducer eventBus, IContactRepository contactRepository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
            _contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Reports>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Reports>>> GetReports()
        {
            var reports = await _repository.GetReports();

            return Ok(reports);
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateLocationReport([FromBody] string location)
        {
            var allContacts = await _contactRepository.GetContacts();

            if (allContacts == null)
            {
                return BadRequest();
            }

            var contactListByLocation = allContacts.Where(x => x.ContactInfo.Select(y => y.Location == location).Any()).ToList();

            if (contactListByLocation == null)
            {
                return BadRequest();
            }

            var reportContext = new ReportContext();

            reportContext.Location = location;

            reportContext.ContactCount=contactListByLocation.GroupBy(y => y.Id).Count();

            reportContext.PhoneNumberCount = contactListByLocation.Select(x => x.ContactInfo.GroupBy(y => y.PhoneNumber)).Count();

            Reports report = new Reports();
            report.ReportContext = reportContext;
           
            var eventMessage = _mapper.Map<ReportsEvent>(report);
            eventMessage.RequestId = Guid.NewGuid();
            eventMessage.Status = true;
            eventMessage.CreationDate = DateTime.Now;
            eventMessage.ReportId = new ObjectId().ToString();

            await _repository.InsertReport(report);


            try
            {
                _eventBus.PublishReports(EventBusConstants.ReportQueue, eventMessage);
            }
            catch (Exception)
            {
                throw;
            }

            return Accepted();
           
        }
    }
}
