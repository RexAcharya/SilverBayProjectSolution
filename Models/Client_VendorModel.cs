using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SilvarBayAPI.Models
{
    public class Client_VendorModel
    {
        [Key]
        public int ClientVendorId { get; set; }
        [ForeignKey("ClientId")]
        public int ClientId { get; set; }
        [ForeignKey("VendorId")]
        public int VendorId { get; set; }
        public virtual ClientModel client { get; set; }
        public virtual VendorModel vendor { get; set; }

        
    }
}
