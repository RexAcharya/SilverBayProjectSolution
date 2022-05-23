using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SilvarBayAPI.Models
{
    public enum Flag { valid, invalid};
    public enum Roles {Consultant, Admin, SuperAdmin};
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        
        public string Address { get; set; }
        [Required]
        public string ContactNumebr { get; set; }

        public string GoogleVoiceNumber { get; set; }
        [Required]
        public Position userPosition { get; set; }
        
        [Required]
        
        public Roles userRole { get; set; }
        [Required]
        public Flag flagStat { get; set; }


    }
}
