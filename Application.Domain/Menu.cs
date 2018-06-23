using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.Domain
{
    public class Menu
    {        
        public Int64 Id { get; set; }
        
        public string Name { get; set; }
        
        public string ControllerName { get; set; }
        
        public string ActionName { get; set; }
        
        public string MenuArea { get; set; }
        
        public Boolean Disable { get; set; }
        
        public Boolean HasAccess { get; set; }

        [ForeignKey(nameof(ParentMenu))]
        public Int64? ParentId { get; set; }
        public Menu ParentMenu { get; set; }        

        [NotMapped]
        public string ParentMenuName { get; set; }
    }
}
