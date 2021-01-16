using MongoDB.Driver;
using PhoneBook.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace PhoneBook.API.Data
{
    public class PhoneBookContextSeed
    {
       
       

        public static void SeedData(IMongoCollection<Contact> contactCollection)
        {
            bool exist = contactCollection.Find(p => true).Any();
            if (!exist)
            {
                contactCollection.InsertManyAsync(GetPreconfiguredContacts());
            }
        }

        private static IEnumerable<Contact> GetPreconfiguredContacts()
        {
            return new List<Contact>()
            {
                new Contact()
                {
                    FirstName = "Asya",
                    LastName = "İlktürk",
                    Company ="Company",
                    
                },
                new Contact()
                {
                    FirstName = "Jane",
                    LastName = "Doe",
                    Company ="Company"
                },
                  new Contact()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Company ="Company"
                }

            };
        }
    }
}
