using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SilvarBayAPI.Models
{
    public class RecruiterModel 
    {

        [Key]
        public int RecruiterId { get; set; }

        public string Name { get; set; }


        public string Location { get; set; }

        public string Address { get; set; }

        public string EmailAddress { get; set; }
        public string ContactNumber { get; set; }

        /*public string Name { get; set; }
        public string Location { get; set; }
        public string EmailAddress { get; set; }
        
        public string ContactNumber { get; set; }*/

        /*[ForeignKey("VendorId")]

        public int VendorId { get; set; }*/


        public virtual VendorModel Vendor { get; set; }
        public virtual WorkSheetModel workSh { get; set; }
    }
}
