using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pallet_system.Models
{
    public class VirtualPallet
    {
        public int ID { get; set; }
        [Required]
        public int PALLET { get; set; }
        [Required]
        public int PROGRAM { get; set; }
        public int STEP { get; set; }
        public int STATUS { get; set; }
        public TimeSpan LAST_UPDATE { get; set; }
        public bool IS_ACTIVE { get; set; }
        public TimeSpan CREATED { get; set; }
        public string LOG_INFO { get; set; }
    }
}
