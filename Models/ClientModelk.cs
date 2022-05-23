using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SilvarBayAPI.Models
{
    public class ClientModelk
    {
        [Key]
        public int ClientId { get; set; }
        public BasicInfoModel ClientBasicInfo { get; set; }
    }
}
