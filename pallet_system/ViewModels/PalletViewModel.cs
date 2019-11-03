using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pallet_system.ViewModels
{
    public class PalletViewModel
    {
        public int ID { get; set; }
        [Required]
        [StringLength(16)]
        [RegularExpression(@"(\d+[.]\d+[.]\d+.\d+)", ErrorMessage = "Ip address in invalid")]
        public string IP { get; set; }
        [Required]
        [StringLength(255)]
        [Remote(action: "IsProductNameExist", controller: "Program")]
        public string NAME { get; set; }
        public int STATUSID { get; set; }
        public string STATUS_NAME { get; set; }
    }
}
