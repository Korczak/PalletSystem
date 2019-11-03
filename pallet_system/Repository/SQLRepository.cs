using pallet_system.DAL;
using pallet_system.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pallet_system.Repository
{
    public class SQLRepository
    {
        protected readonly PalletSystemContext context;
        public SQLRepository(PalletSystemContext palletSystemContext)
        {
            context = palletSystemContext;
        }
    }
}
