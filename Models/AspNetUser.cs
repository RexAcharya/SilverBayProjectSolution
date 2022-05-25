using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SilvarBayAPI.Models
{
    public class AppUser:IdentityUser
    {
        

        
        
        public virtual ConsultantModel Consultant { get; set; }
        public virtual WorkSheetModel WorkSheet { get; set; }

        public virtual UserInvitationModel userinvitation { get; set; }
    }
}
