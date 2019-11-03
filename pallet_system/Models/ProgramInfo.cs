using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pallet_system.Models
{
    public class ProgramInfo
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
    }
}
