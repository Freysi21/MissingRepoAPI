﻿using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Reporter
    {
        public Reporter()
        {
            Reports = new HashSet<Report>();
        }

        public Guid Id { get; set; }
        public string Ssn { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        //public string Phone {get; set;}
        public virtual ICollection<Report> Reports { get; set; }
    }
}
