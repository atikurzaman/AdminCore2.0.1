using System;
using System.Collections.Generic;

namespace Application.Domain.Membership
{
    public class Role
    {
        public Int64 Id { get; set; }
        public string ConcurrencyStamp { get;set;}
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
