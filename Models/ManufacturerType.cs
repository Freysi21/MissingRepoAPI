using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class ManufacturerType
    {
        public Guid TypeId { get; set; }
        public Guid ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
        public virtual Type Type { get; set; }
    }
}
