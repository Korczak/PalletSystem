using pallet_system.DAL;
using pallet_system.Interfaces;
using pallet_system.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace pallet_system.Repository
{
    public class PalletRepository : SQLRepository, IRepository<Pallet>
    {
        public PalletRepository(PalletSystemContext palletSystemContext) : base(palletSystemContext)
        {
        }

        public Pallet AddAndSave(Pallet pallet)
        {
            context.PALLET.Add(pallet);
            context.SaveChanges();
            return pallet;
        }

        public Pallet Add(Pallet pallet)
        {
            context.PALLET.Add(pallet);
            return pallet;
        }

        public Pallet Delete(int id)
        {
            var pallet = context.PALLET.Find(id);
            if (pallet != null)
            {
                context.PALLET.Remove(pallet);
                context.SaveChanges();
            }
            return pallet;
        }

        public IEnumerable<Pallet> GetAll()
        {
            return context.PALLET;
        }

        public Pallet GetById(int id)
        {
            return context.PALLET.Find(id);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public Pallet Update(Pallet palletChanges)
        {
            var pallet = context.PALLET.Attach(palletChanges);
            pallet.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return palletChanges;
        }
    }
}
