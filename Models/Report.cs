using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Report
    {
        public Guid Id { get; set; }
        public Guid TypeId { get; set; }
        public Guid ManufacturerId { get; set; }
        public Guid StatusId { get; set; }
        public Guid ReporterId { get; set; }
        public int Worth { get; set; }
        public DateTime DateLost { get; set; }
        public string ProductionNumber { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
        public virtual Reporter Reporter { get; set; }
        public virtual Status Status { get; set; }
        public virtual Type Type { get; set; }
        public virtual ReportComment ReportComment { get; set; }
    }
}
