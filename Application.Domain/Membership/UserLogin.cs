using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.Domain.Membership
{
    public class UserLogin
    {   
        public Int64 Id { get; set; }

        public Int64 LoginProvider { get; set; }  
        
        public Int64 ProviderKey { get; set; }

        public string ProviderDisplayName { get; set; }

        //[Required, ForeignKey(nameof(User))]
        public Int64 UserId { get; set; }

        public virtual User User { get; set; }
    }
}
