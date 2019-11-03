using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pallet_system.Models
{
    public class WebRole
    {
        [Key]
        public int WEBROLE_ID { get; set; }

        [Required]
        [StringLength(63)]
        public string NAME { get; set; }

    }
}
