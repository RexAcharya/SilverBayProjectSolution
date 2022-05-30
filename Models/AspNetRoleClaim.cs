using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace SilvarBayAPI.Models
{
    public partial class AspNetRoleClaim :IdentityRoleClaim<string>
    {
        public override int Id { get; set; }
        public override string RoleId { get; set; }
        public override string ClaimType { get; set; }
        public override string ClaimValue { get; set; }

        public virtual AspNetRole Role { get; set; }
    }
}
