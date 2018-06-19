using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.Domain
{
    public class Menu
    {
        [Column(Order = 0)]
        public Int64 Id { get; set; }

        [Column(Order = 1)]
        public string Name { get; set; }

        [Column(Order = 2)]
        public string ControllerName { get; set; }

        [Column(Order = 3)]
        public string ActionName { get; set; }

        [Column(Order = 4)]
        public string MenuArea { get; set; }

        [Column(Order = 5)]
        public Boolean Disable { get; set; }

        [Column(Order = 6)]
        public Boolean HasAccess { get; set; }

        [ForeignKey(nameof(ParentMenu))]
        public Int64? ParentId { get; set; } = null;
        public virtual Menu ParentMenu { get; set; }        

        [NotMapped]
        public string ParentMenuName { get; set; }
    }
}
