﻿using Report.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Report.API.Repositories.Interfaces
{
    public interface IReportRepository
    {

        //Oluşturulmuş raporların listelenmesi
        Task<IEnumerable<Reports>> GetReports();

        //Location bilgisine göre rapor oluşturma
        Task<ReportContext> CreateReportByLocation(string Location);

   

    }
}
