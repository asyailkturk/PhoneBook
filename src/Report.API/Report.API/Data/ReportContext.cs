using MongoDB.Driver;
using Report.API.Data.Interfaces;
using Report.API.Entities;
using Report.API.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Report.API.Data
{
    public class ReportContext : IReportContext
    {
        public ReportContext(IReportDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            PhoneBookReports = database.GetCollection<Reports>(settings.CollectionName);
        }
        public IMongoCollection<Reports> PhoneBookReports { get; }
    }
}
