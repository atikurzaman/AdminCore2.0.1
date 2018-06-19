using Application.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Web.Areas.Admin.Models
{
    public class MenuViewModel
    {  
        public Int64 Id { get; set; }

        [Required, DisplayName("Name")]
        public string Name { get; set; }

        [Required, DisplayName("Controller Name")]
        public string ControllerName { get; set; }

        [Required,DisplayName("Action Name")]
        public string ActionName { get; set; }

        [DisplayName("Menu Area")]
        public string MenuArea { get; set; }
        public Boolean Disable { get; set; }

        [DisplayName("Has Access")]
        public Boolean HasAccess { get; set; }

        [DisplayName("Parent Menu")]
        public Int64? ParentId { get; set; } = null;
        public virtual Menu ParentMenu { get; set; }
        public SelectList MenuSelectList { get; set; }

        [DisplayName("Parent Menu Name")]
        public string ParentMenuName { get; set; }
    }
}
