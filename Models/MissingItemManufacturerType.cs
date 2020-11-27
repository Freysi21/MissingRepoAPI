using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class MissingItemManufacturerType
    {
        public int TypeId { get; set; }
        public int ManufacturerId { get; set; }

        public virtual MissingItemManufacturer Manufacturer { get; set; }
        public virtual MissingItemType Type { get; set; }
    }
}
