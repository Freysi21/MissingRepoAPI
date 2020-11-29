using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            ManufacturerTypes = new HashSet<ManufacturerType>();
            Reports = new HashSet<Report>();
        }

        public Manufacturer(Guid id, string name)
        {
            this.Id = id;
            this.Name = name;
            ManufacturerTypes = new HashSet<ManufacturerType>();
            Reports = new HashSet<Report>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ManufacturerType> ManufacturerTypes { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
