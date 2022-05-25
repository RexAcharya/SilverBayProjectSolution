﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SilvarBayAPI.Models
{
    public enum Flag { valid, invalid};
    public enum Roles {Consultant, Admin, SuperAdmin};
    public class ConsultantModel
    {
        [Key]
        public int consultantId { get; set; }



        [ForeignKey("UserId")]
        public string UserId { get; set; }

        public virtual AppUser User { get; set; }


        public string Address { get; set; }
       
       
        public string GoogleVoiceNumber { get; set; }
       
        public Position userPosition { get; set; }
        
       
       
        public Flag flagStat { get; set; }


    }

    
}