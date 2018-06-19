using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.Domain
{
    public class EntityRecord
    {       

        [Column(Order =100)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Column(Order = 101)]
        public DateTime? ModifiedDate { get; set; }

        [Column(Order = 102)]
        public Int64 CreatedBy { get; set; }

        [Column(Order = 103)]
        public Int64? ModifiedBy { get; set; }

        [Column(Order = 104)]
        public string IPAddress { get; set; }

        [Column(Order = 105)]
        public string MacAddress { get; set; }
    }
}
