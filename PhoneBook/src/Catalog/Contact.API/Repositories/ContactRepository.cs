using Microsoft.AspNetCore.Server.IIS.Core;
using MongoDB.Driver;
using PhoneBook.API.Data.Interfaces;
using PhoneBook.API.Entities;
using PhoneBook.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.API.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly IPhoneBookContext _context;

        public ContactRepository(IPhoneBookContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Contact> GetContactById(string id)
        {
            return await _context
                           .Contacts
                           .Find(p => p.Id == id)
                           .FirstOrDefaultAsync();
        }

        //In order to use lazy loading
        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await _context
                           .Contacts
                           .Find(p => true)
                           .ToListAsync();
        }

        public async Task AddContactInfo(string id, ContactInfo contactInfo)
        {

            var updateResult = _context
                                  .Contacts
                                  .Find(p => p.Id == id)
                                  .Single();


            if (contactInfo != null)

                updateResult.ContactInfo.Add(contactInfo);

            await _context.Contacts.ReplaceOneAsync(p => p.Id == id, updateResult);


        }

        public async Task Create(Contact contact)
        {
            await _context.Contacts.InsertOneAsync(contact);
        }

        public async Task<bool> Delete(string id)
        {
            FilterDefinition<Contact> filter = Builders<Contact>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context
                                                .Contacts
                                                .DeleteOneAsync(filter);


            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;

           
        }

        public async Task DeleteContactInfo(string id, int phoneNumber)
        {

            var updateResult = _context
                                  .Contacts
                                  .Find(p => p.Id == id)
                                  .Single();

            var removingItem = updateResult.ContactInfo.Find(x => x.PhoneNumber == phoneNumber);

            if (removingItem != null)
                updateResult.ContactInfo.Remove(removingItem);

            await _context.Contacts.ReplaceOneAsync(p => p.Id == id, updateResult);


        }
    }
    
}
