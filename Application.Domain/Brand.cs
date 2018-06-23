using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Domain
{
    public class Brand:BaseEntity
    {
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
