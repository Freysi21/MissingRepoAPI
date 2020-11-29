using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Status
    {
        public Status()
        {
            Reports = new HashSet<Report>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
    }
}
