using pallet_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pallet_system.ViewModels
{
    public class EditPalletViewModel : PalletViewModel
    {
        public IEnumerable<Status> STATUSES_INFO { get; set; }
    }
}
