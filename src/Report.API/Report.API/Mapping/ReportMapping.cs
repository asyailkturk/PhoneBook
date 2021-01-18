using AutoMapper;
using EventBusRabbitMQ.Events;
using Report.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Report.API.Mapping
{
    public class ReportMapping : Profile
    {
        public ReportMapping()
        {
            CreateMap<Reports, ReportsEvent>().ReverseMap();
        }
    }
}
