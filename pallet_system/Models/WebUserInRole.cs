using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pallet_system.Models
{
    public class WebUserInRole
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int WEBUSER_ID { get; set; }

        [Required]
        public int WEBROLE_ID { get; set; }

        public virtual WebUser WEBUSER { get; set; }

        public virtual WebRole WEBROLE { get; set; }
    }
}
