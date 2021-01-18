using Microsoft.AspNetCore.Mvc;
using PhoneBook.API.Entities;
using PhoneBook.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PhoneBook.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PhoneBookController : ControllerBase
    {
        private readonly IContactRepository _repository;

        public PhoneBookController(IContactRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Contact>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
            var contacts = await _repository.GetContacts();

            return Ok(contacts);
        }

        [HttpGet("{id}", Name = "GetContact")]
        [ProducesResponseType(typeof(Contact), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<Contact>> GetContactById(string id)
        {
            var contact = await _repository.GetContactById(id);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Contact), (int)HttpStatusCode.OK)]
       
        public async Task<ActionResult<Contact>> CreateContact([FromBody] Contact contact)
        {
             await _repository.Create(contact);

            return CreatedAtRoute("GetContact", new { id = contact.Id }, contact);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Contact), (int)HttpStatusCode.OK)]

        public async Task<ActionResult> DeleteContact(string id)
        {


            return Ok(await _repository.Delete(id));
        }

        [Route("{id}/[action]")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> AddContactInfo(string id, [FromBody]ContactInfo contactInfo)
        {
            await _repository.AddContactInfo(id, contactInfo);

            return Ok();
        }


        [Route("{id}/[action]/{phoneNumber}")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteContactInfo(string id, long phoneNumber)
        {
            await _repository.DeleteContactInfo(id, phoneNumber);

            return Ok();
        }

    }
    
}
