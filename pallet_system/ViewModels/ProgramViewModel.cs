using Microsoft.AspNetCore.Mvc;
using pallet_system.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pallet_system.ViewModels
{
    public class ProgramViewModel : CreateProgramViewModel
    {
        public List<ProgramData> PROGRAMS { get; set; }
    }

}
