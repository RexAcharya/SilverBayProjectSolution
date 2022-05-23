
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SilvarBayAPI.Models
{
    public enum Position { Developer, DevOps, QA, DataScience };
    public class PositionModel
    {
        public int Id { get; set; }
        public string Position { get; set; }

    }
}
