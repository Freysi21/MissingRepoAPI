using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Type
    {
        public Type()
        {
            ManufacturerTypes = new HashSet<ManufacturerType>();
            Reports = new HashSet<Report>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ManufacturerType> ManufacturerTypes { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
