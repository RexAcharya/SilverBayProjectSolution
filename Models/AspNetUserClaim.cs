using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace SilvarBayAPI.Models
{
    public partial class AspNetUserClaim : IdentityUserClaim<string>
    {
        public override int Id { get; set; }
        public override string UserId { get; set; }
        public override string ClaimType { get; set; }
        public override string ClaimValue { get; set; }

        public virtual AspNetUser User { get; set; }
    }
}
