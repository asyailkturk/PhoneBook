using MongoDB.Driver;
using PhoneBook.API.Data.Interfaces;
using PhoneBook.API.Entities;
using PhoneBook.API.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.API.Data
{
    public class PhoneBookContext : IPhoneBookContext
    {
        public PhoneBookContext(IPhoneBookDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            Contacts = database.GetCollection<Contact>(settings.CollectionName);

            PhoneBookContextSeed.SeedData(Contacts);

        }

        public IMongoCollection<Contact> Contacts { get; }

        
    }
}
