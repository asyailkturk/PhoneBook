using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.API.Entities
{
    public class ContactInfo
    {
        public long PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Location { get; set; }

        public string Detail { get; set; }

    }
}
