using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pallet_system.Models
{
    public class WebUser : IdentityUser
    {

        public WebUser()
        {
            WEBUSERINROLES = new HashSet<WebUserInRole>();
        }

        [Key]
        public int WEBUSER_ID { get; set; }

        [Required]
        [StringLength(63)]
        public string EMAIL { get; set; }

        [Required]
        [StringLength(63)]
        public string PASSWD { get; set; }

        public virtual ICollection<WebUserInRole> WEBUSERINROLES { get; set; }
    }
}
