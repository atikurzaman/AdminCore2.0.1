using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.Domain
{
    public class Store
    {
        [Column(Order = 0)]
        public Int64 Id { get; set; }

        [Column(Order = 1)]
        public string Name { get; set; }                

        [Column(Order = 2)]
        public Boolean Status { get; set; }
    }
}
