using MongoDB.Driver;
using PhoneBook.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.API.Data.Interfaces
{
    public interface IPhoneBookContext
    {
        IMongoCollection<Contact> Contacts { get; }
    }
}
