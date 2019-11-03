using pallet_system.Interfaces;
using pallet_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pallet_system.Manager
{
    public class StatusManager : IManager<Status>
    {
        private readonly IRepository<Status> statusRepository;

        public StatusManager(IRepository<Status> statusRepository)
        {
            this.statusRepository = statusRepository;
        }
        public Status Delete(Status model)
        {
            throw new NotImplementedException();
        }

        public Status Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Status> GetAll()
        {
            return statusRepository.GetAll();
        }

        public Status GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Status Update(Status model)
        {
            throw new NotImplementedException();
        }
    }
}
