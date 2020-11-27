using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class MissingItemReport
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public int ManufacturerId { get; set; }
        public int StatusId { get; set; }
        public int ReporterId { get; set; }
        public int Worth { get; set; }
        public DateTime DateLost { get; set; }
        public string ProductionNumber { get; set; }

        public virtual MissingItemManufacturer Manufacturer { get; set; }
        public virtual Reporter Reporter { get; set; }
        public virtual MissingItemStatus Status { get; set; }
        public virtual MissingItemType Type { get; set; }
        public virtual MissingItemReportComment MissingItemReportComment { get; set; }
    }
}
