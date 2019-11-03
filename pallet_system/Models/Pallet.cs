using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pallet_system.Models
{
    public class Pallet
    {
        [Key]
        public int? ID { get; set; }
        [Required]
        [StringLength(16)]
        [RegularExpression(@"(\d+[.]\d+[.]\d+.\d+)", ErrorMessage = "Ip address in invalid")]
        public string IP { get; set; }
        [Required]
        [StringLength(255)]
        public string NAME { get; set; }
        public DateTime? ADDED_TIME { get; set; }
        public int? STATUS { get; set; }
    }
}
