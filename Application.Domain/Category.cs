using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Domain
{

    public class Category 
    {
        public Int64 Id { get; set; }

        [Column(Order = 0)]
        public string Name { get; set; }
    }
}
