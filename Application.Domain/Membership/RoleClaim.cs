using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.Domain.Membership
{
    public class RoleClaim
    {
        public Int64 Id { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

        //[Required, ForeignKey(nameof(Role))]
        public Int64 RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
