﻿using Microsoft.AspNetCore.Mvc;
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

        public ReportController(IReportRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Reports>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Reports>>> GetReports()
        {
            var reports = await _repository.GetReports();

            return Ok(reports);
        }

        [Route("[action]/{location}")]
        [HttpPut]
        [ProducesResponseType(typeof(ReportContext),(int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<ReportContext>> CreateReportByLocation([FromBody]string location)
        {
            var reportContext =await _repository.CreateReportByLocation(location);

            if(reportContext == null)
            {
                return NotFound();
            }
            
            return Ok(reportContext);
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ActionResult<ReportContext>> GetLocationReport([FromBody] string location)
        {

            //var basket = await _repository.GetBasket(basketCheckout.UserName);
            //if (basket == null)
            //{
            //    return BadRequest();
            //}
            //var basketRemoved = await _repository.DeleteBasket(basket.UserName);
            //if (!basketRemoved)
            //{
            //    return BadRequest();
            //}

            //var eventMessage = _mapper.Map<BasketCheckoutEvent>(basketCheckout);
            //eventMessage.RequestId = Guid.NewGuid();
            //eventMessage.TotalPrice = basket.TotalPrice;

            //try
            //{
            //    _eventBus.PublishBasketCheckout(EventBusConstants.BasketCheckoutQueue, eventMessage);
            //}
            //catch (Exception)
            //{
            //    throw;
            //}

           return Accepted();
        }
    }
}
