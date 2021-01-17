using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Report.API.Entities
{
    public class Reports
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ReportId { get; set; }

        public DateTime CreationDate { get; set; }

        //Status false for "Prepairing" and true for "Done"
        public bool Status { get; set; }

    }
}
