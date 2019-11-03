using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pallet_system.Models
{
    [Table("PROGRAM")]
    public class ProgramData
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int PROGRAM_ID { get; set; }
        [Required]
        public int STEP { get; set; }
        [Required]
        [StringLength(10)]
        public string MACHINE_MASK { get; set; }
        [Required]
        [StringLength(255)]
        public string COMMAND { get; set; }
        [StringLength(255)]
        public string PARAMETER_1 { get; set; }
        [StringLength(255)]
        public string PARAMETER_2 { get; set; }
        [StringLength(255)]
        public string PARAMETER_3 { get; set; }
        [StringLength(255)]
        public string PARAMETER_4 { get; set; }
        [StringLength(255)]
        public string PARAMETER_5 { get; set; }
    }
}
