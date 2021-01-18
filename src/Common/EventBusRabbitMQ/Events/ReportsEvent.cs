using System;


namespace EventBusRabbitMQ.Events
{
    public class ReportsEvent
    {
        
        public Guid RequestId { get; set; }

        public string ReportId { get; set; }

        public DateTime CreationDate { get; set; }

        public bool Status { get; set; }

    }
}
