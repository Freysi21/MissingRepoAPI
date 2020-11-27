using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class MissingItemReportComment
    {
        public int Id { get; set; }
        public string Comment { get; set; }

        public virtual MissingItemReport IdNavigation { get; set; }
    }
}
