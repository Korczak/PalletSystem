using pallet_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pallet_system.Interfaces
{
    /// <summary>
    /// Interface for repositories that uses Database or other storage
    /// </summary>
    /// <typeparam name="Type"></typeparam>
    public interface IRepository<Type>
    {
        Type GetById(int id);
        IEnumerable<Type> GetAll();
        Type Delete(int id);
        Type Update(Type type);
        Type Add(Type type);
        Type AddAndSave(Type type);

        void SaveChanges();
    }
}
