using MongoDB.Driver;
using Report.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Report.API.Data.Interfaces
{
    public interface IReportContext
    {
        IMongoCollection<Reports> PhoneBookReports { get; }
    }
}
