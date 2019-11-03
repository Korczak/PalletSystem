using pallet_system.DAL;
using pallet_system.Interfaces;
using pallet_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pallet_system.Repository
{
    public class StatusRepository : SQLRepository, IRepository<Status>
    {
        public StatusRepository(PalletSystemContext palletSystemContext) : base(palletSystemContext)
        {
        }

        public Status AddAndSave(Status status)
        {
            context.STATUS.Add(status);
            context.SaveChanges();
            return status;
        }

        public Status Add(Status status)
        {
            context.STATUS.Add(status);
            return status;
        }

        public Status Delete(int id)
        {
            var status = context.STATUS.Find(id);
            if (status != null)
            {
                context.STATUS.Remove(status);
                context.SaveChanges();
            }
            return status;
        }

        public IEnumerable<Status> GetAll()
        {
            return context.STATUS;
        }

        public Status GetById(int id)
        {
            return context.STATUS.Find(id);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public Status Update(Status statusChanges)
        {
            var status = context.STATUS.Attach(statusChanges);
            status.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return statusChanges;
        }
    }
}
