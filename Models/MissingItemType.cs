using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class MissingItemType
    {
        public MissingItemType()
        {
            MissingItemManufacturerTypes = new HashSet<MissingItemManufacturerType>();
            MissingItemReports = new HashSet<MissingItemReport>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MissingItemManufacturerType> MissingItemManufacturerTypes { get; set; }
        public virtual ICollection<MissingItemReport> MissingItemReports { get; set; }
    }
}
