using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SilvarBayAPI.Models
{
    public enum VisaStatus  {OPT, CPT, H1B, GreenCard, Citizen};
    public class VISA_STATUS_Model
    {
        public int VisaStatusId { get; set; }
        public VisaStatus statusV { get; set; }
    }
}
