using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class ReportComment
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }

        public virtual Report IdNavigation { get; set; }
    }
}
