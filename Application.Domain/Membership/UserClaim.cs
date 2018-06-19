using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.Domain.Membership
{
    public class UserClaim
    {
        public Int64 Id { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

        //[Required, ForeignKey(nameof(User))]
        public Int64 UserId { get; set; }

        public virtual User User { get; set; }
    }
}
