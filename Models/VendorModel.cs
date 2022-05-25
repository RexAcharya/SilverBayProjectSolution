using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SilvarBayAPI.Models
{
    public class VendorModel 
    {
        [Key]
        public int VendorId { get; set; }

        [Required(ErrorMessage = "VendorName is required")]
        [Column(TypeName = "nvarchar(100)")]
        public string VendorName { get; set; }

        [Required(ErrorMessage ="Vendor phone number is required")]
        [Column(TypeName = "nvarchar(100)")]
        public string VendorPhone { get; set; }

        public string Location { get; set; }
        public string EmailAddress { get; set; }
        
        public string ContactNumber { get; set; }


        public virtual ICollection<RecruiterModel> RecruiterList { get; set; }
        public virtual List<Client_VendorModel> cvlist { get; set; }
        public virtual WorkSheetModel workSh { get; set; }
    }
}
