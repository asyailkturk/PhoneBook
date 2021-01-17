using MongoDB.Driver;
using Report.API.Data.Interfaces;
using Report.API.Entities;
using Report.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Report.API.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly IReportContext _context;
        

        public ReportRepository(IReportContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public  Task<ReportContext> CreateReportByLocation(string Location)
        {
            throw new Exception();
        }

        public async Task<IEnumerable<Reports>> GetReports()
        {
            return await _context
                            .PhoneBookReports
                            .Find(p => true)
                            .ToListAsync();
        }
    }
}
