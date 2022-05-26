using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;

namespace SilvarBayAPI.Models
{
    public class WorkSheetModel
    {
        [Key]
        public int WorkSheetId { get; set; }
        //foreignkey


        //foreignKey
        public int VendorId { get; set; }

        

        public virtual AspNetUser AUser { get; set; }
        public virtual VendorModel vendor { get; set; }
        //foreignkey
        public int RecruiterId { get; set; }
        public virtual RecruiterModel recruiter { get; set; }
        //foreignKey
        public int ClientId { get; set; }
        public virtual ClientModel client { get; set; }
        //foreignkey
        public JobLocation jobLocation { get; set; }
        //foreingkey

        public Position position { get; set; }

        [Required]
        public VisaStatus visa_status { get; set; }
        
        public JobStatus jobStatus { get; set; }

        public string Remarks { get; set; }

    }
}
