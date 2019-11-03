using pallet_system.DAL;
using pallet_system.Interfaces;
using pallet_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pallet_system.Repository
{
    public class VirtualPalletRepository : SQLRepository, IRepository<VirtualPallet>
    {
        public VirtualPalletRepository(PalletSystemContext palletSystemContext) : base(palletSystemContext)
        {
        }

        public VirtualPallet AddAndSave(VirtualPallet pallet)
        {
            context.VIRTUAL_PALLET.Add(pallet);
            context.SaveChanges();
            return pallet;
        }

        public VirtualPallet Add(VirtualPallet pallet)
        {
            context.VIRTUAL_PALLET.Add(pallet);
            return pallet;
        }

        public VirtualPallet Delete(int id)
        {
            var pallet = context.VIRTUAL_PALLET.Find(id);
            if (pallet != null)
            {
                context.VIRTUAL_PALLET.Remove(pallet);
                context.SaveChanges();
            }
            return pallet;
        }

        public IEnumerable<VirtualPallet> GetAll()
        {
            return context.VIRTUAL_PALLET;
        }

        public VirtualPallet GetById(int id)
        {
            return context.VIRTUAL_PALLET.Find(id);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public VirtualPallet Update(VirtualPallet palletChanges)
        {
            var pallet = context.VIRTUAL_PALLET.Attach(palletChanges);
            pallet.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return palletChanges;
        }
    }
}
