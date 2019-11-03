using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pallet_system.Interfaces
{
    /// <summary>
    /// Interface of database managers that controllers uses.
    /// </summary>
    /// <typeparam name="VieModel"></typeparam>
    public interface IManager<VieModel>
    {
        public VieModel Delete(VieModel model);

        public VieModel Delete(int id);

        public IEnumerable<VieModel> GetAll();

        public VieModel GetById(int id);

        public VieModel Update(VieModel model);
    }
}
