using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace SilvarBayAPI.Models
{
    public partial class AspNetUserToken:IdentityUserToken<string>
    {
        public override string UserId { get; set; }
        public override string LoginProvider { get; set; }
        public override string Name { get; set; }
        public override string Value { get; set; }

        public virtual AspNetUser User { get; set; }
    }
}
