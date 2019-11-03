using pallet_system.DAL;
using pallet_system.Interfaces;
using pallet_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pallet_system.Repository
{
    public class ProgramDataRepository : SQLRepository, IRepository<ProgramData>
    {

        public ProgramDataRepository(PalletSystemContext context) : base(context)
        {}

        public ProgramData Add(ProgramData program)
        {
            context.PROGRAM.Add(program);
            return program;
        }

        public ProgramData AddAndSave(ProgramData program)
        {
            context.PROGRAM.Add(program);
            context.SaveChanges();
            return program;
        }

        public ProgramData Delete(int id)
        {
            var program = context.PROGRAM.Find(id);
            if(program != null)
            {
                context.PROGRAM.Remove(program);
                context.SaveChanges();
            }
            return program;
        }

        public IEnumerable<ProgramData> GetAll()
        {
            return context.PROGRAM;
        }

        public ProgramData GetById(int id)
        {
            return context.PROGRAM.Find(id);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public ProgramData Update(ProgramData programChanges)
        {
            var program = context.PROGRAM.Attach(programChanges);
            program.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return programChanges;
        }
    }
}
