using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SilvarBayAPI.Models
{
    public enum InvitationStat { Pending, Confirmed, NotInvited};
    public class UserInvitationModel
    {
        [Key]
        public string Id { get; set; }

        public string AspUserID;

        [ForeignKey("AspUserID")]

        public virtual AspNetUser AUser { get; set; }



        [Required(ErrorMessage = "Email is required")]
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [Column("InvitationStat")]
        public InvitationStat inviteS { get; set; }

    }
}
