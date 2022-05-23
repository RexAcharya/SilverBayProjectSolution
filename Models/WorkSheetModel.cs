using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SilvarBayAPI.Models
{
    public class WorkSheetModel
    {
        [Key]
        public int WorkSheetId { get; set; }
        //foreignkey
        public int UserId { get; set; }
        //foreignKey
        public int VendorId { get; set; }
        //foreignkey
        public int RecruiterId { get; set; }
        //foreignKey
        public int ClientId { get; set; }
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
