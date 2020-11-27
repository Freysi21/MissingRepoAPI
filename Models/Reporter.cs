using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Reporter
    {
        public Reporter()
        {
            MissingItemReports = new HashSet<MissingItemReport>();
        }

        public int Id { get; set; }
        public string Ssn { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public virtual ICollection<MissingItemReport> MissingItemReports { get; set; }
    }
}
