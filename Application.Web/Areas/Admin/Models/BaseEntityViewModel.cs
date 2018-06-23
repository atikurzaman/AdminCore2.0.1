using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Web.Areas.Admin.Models
{
    public class BaseEntityViewModel
    {
        public Int64 Id { get; set; }

        [Required, DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [DisplayName("Modified Date")]
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;

        [Required, DisplayName("Created By")]
        public Int64 CreatedBy { get; set; } = 1;

        [DisplayName("Modified By")]
        public Int64? ModifiedBy { get; set; } = 2;

        [MaxLength(256), DisplayName("IP Address")]
        public string IPAddress { get; set; } = "127.0.0.1";

        [MaxLength(256), DisplayName("Mac Address")]
        public string MacAddress { get; set; }= "00:1B:44:11:3A:B7";
    }
}
