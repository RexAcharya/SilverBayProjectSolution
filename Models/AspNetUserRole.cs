using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace SilvarBayAPI.Models
{
    public partial class AspNetUserRole : IdentityUserRole<string>
    
    { 
        public override string UserId { get; set; }
        public override string RoleId { get; set; }

        public virtual AspNetRole Role { get; set; }
        public virtual AspNetUser User { get; set; }
    }
}
