using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.Domain.Membership
{    
    public class UserRole
    {   
        //[Required, ForeignKey(nameof(User))]
        public Int64 UserId { get; set; }
        
        //[Required, ForeignKey(nameof(Role))]
        public Int64 RoleId { get; set; }

        public virtual Role Role { get; set; }

        public virtual User User { get; set; }
    }
}
