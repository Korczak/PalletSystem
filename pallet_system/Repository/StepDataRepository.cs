using pallet_system.DAL;
using pallet_system.Interfaces;
using pallet_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pallet_system.Repository
{
    public class StepDataRepository : SQLRepository, IRepository<StepData>
    {
        public StepDataRepository(PalletSystemContext palletSystemContext) : base(palletSystemContext)
        {
        }

        public StepData AddAndSave(StepData stepData)
        {
            context.STEP_DATA.Add(stepData);
            context.SaveChanges();
            return stepData;
        }

        public StepData Add(StepData stepData)
        {
            context.STEP_DATA.Add(stepData);
            return stepData;
        }

        public StepData Delete(int id)
        {
            var stepData = context.STEP_DATA.Find(id);
            if (stepData != null)
            {
                context.STEP_DATA.Remove(stepData);
                context.SaveChanges();
            }
            return stepData;
        }

        public IEnumerable<StepData> GetAll()
        {
            return context.STEP_DATA;
        }

        public StepData GetById(int id)
        {
            return context.STEP_DATA.Find(id);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public StepData Update(StepData stepDataChanges)
        {
            var stepData = context.STEP_DATA.Attach(stepDataChanges);
            stepData.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return stepDataChanges;
        }
    }
}
