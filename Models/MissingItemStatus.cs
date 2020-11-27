using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class MissingItemStatus
    {
        public MissingItemStatus()
        {
            MissingItemReports = new HashSet<MissingItemReport>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MissingItemReport> MissingItemReports { get; set; }
    }
}
