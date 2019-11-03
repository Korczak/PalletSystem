using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace pallet_system.Models
{
    public class StepData
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int PALLET { get; set; }
        [Required]
        public int VIRTUAL_PALLET { get; set; }
        [Required]
        public int PROGRAM { get; set; }
        [Required]
        public int STEP { get; set; }
        [Required]
        public int STATUS { get; set; }
        public DateTime DATA { get; set; }
        public string LOG_INFO { get; set; }
        public string LOG_ERROR { get; set; }

    }
}
