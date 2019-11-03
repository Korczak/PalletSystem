using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pallet_system.Models
{
    public class Status
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string NAME { get; set; }
    }
}
