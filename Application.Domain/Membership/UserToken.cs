using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Domain.Membership
{
    public class UserToken
    {
        public Int64 UserId { get; set; }

        public string LoginProvider { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public virtual User User { get; set; }
    }
}
