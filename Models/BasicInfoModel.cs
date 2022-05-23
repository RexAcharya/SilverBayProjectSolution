using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SilvarBayAPI.Models
{
    public class BasicInfoModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Location { get; set; }
        
        public string Address { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        public string ContactNumber { get; set; }
    }
}
