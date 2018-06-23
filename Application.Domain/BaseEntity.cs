using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.Domain
{    
    public class BaseEntity
    {
        public Int64 Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;
        public Int64 CreatedBy { get; set; } = 1;
        public Int64? ModifiedBy { get; set; } = 2;

        [MaxLength(256)]
        public string IPAddress { get; set; } = "127.0.0.1";

        [MaxLength(256)]
        public string MacAddress { get; set; } = "00:1B:44:11:3A:B7";
    }
}
