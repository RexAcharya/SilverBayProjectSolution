using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace SilvarBayAPI.Models
{
    public partial class AspNetUserLogin:IdentityUserLogin<string>

    {

        public  override string LoginProvider { get; set; }
        public override string ProviderKey { get; set; }
        public override string ProviderDisplayName { get; set; }
        public override string UserId { get; set; }

        public virtual AspNetUser User { get; set; }
    }
}
