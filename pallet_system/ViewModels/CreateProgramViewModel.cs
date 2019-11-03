using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pallet_system.ViewModels
{
    public class CreateProgramViewModel
    {
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        [Remote(action: "IsProductNameExist", controller: "Program")]
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
    }
}
