using pallet_system.DAL;
using pallet_system.Interfaces;
using pallet_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pallet_system.Repository
{
    public class ProgramInfoRepository : SQLRepository, IRepository<ProgramInfo>
    {
        public ProgramInfoRepository(PalletSystemContext palletSystemContext) : base(palletSystemContext)
        {
        }

        public ProgramInfo AddAndSave(ProgramInfo program)
        {
            context.PROGRAM_INFO.Add(program);
            context.SaveChanges();
            return program;
        }

        public ProgramInfo Add(ProgramInfo program)
        {
            context.PROGRAM_INFO.Add(program);
            return program;
        }

        public ProgramInfo Delete(int id)
        {
            var program = context.PROGRAM_INFO.Find(id);
            if (program != null)
            {
                context.PROGRAM_INFO.Remove(program);
                context.SaveChanges();
            }
            return program;
        }

        public IEnumerable<ProgramInfo> GetAll()
        {
            return context.PROGRAM_INFO;
        }

        public ProgramInfo GetById(int id)
        {
            return context.PROGRAM_INFO.Find(id);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public ProgramInfo Update(ProgramInfo programChanges)
        {
            var program = context.PROGRAM_INFO.Attach(programChanges);
            program.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return programChanges;
        }
    }
}
