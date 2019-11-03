using pallet_system.Interfaces;
using pallet_system.Models;
using pallet_system.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pallet_system.Manager
{
    public class ProgramManager : IManager<ProgramViewModel>
    {
        private readonly IRepository<ProgramData> programDataRepository;
        private readonly IRepository<ProgramInfo> programInfoRepository;

        public ProgramManager(IRepository<ProgramData> programDataRepository,
                              IRepository<ProgramInfo> programInfoRepository)
        {
            this.programDataRepository = programDataRepository;
            this.programInfoRepository = programInfoRepository;
        }

        public CreateProgramViewModel AddProgramInfo(CreateProgramViewModel program)
        {
            var programInfo = new ProgramInfo()
            {
                NAME = program.NAME,
                DESCRIPTION = program.DESCRIPTION
            };
            programInfoRepository.AddAndSave(programInfo);
            program.ID = programInfo.ID;
            return program;
        }

        public ProgramViewModel AddProgramData(ProgramViewModel program)
        {
            foreach (var programData in program.PROGRAMS)
            {
                programDataRepository.AddAndSave(programData);
            }

            return program;
        }

        public ProgramViewModel AddAndSave(ProgramViewModel program)
        {
            var programInfo = new ProgramInfo()
            {
                ID = program.ID,
                NAME = program.NAME,
                DESCRIPTION = program.DESCRIPTION
            };
            programInfoRepository.AddAndSave(programInfo);

            foreach (var programData in program.PROGRAMS)
            {
                programDataRepository.AddAndSave(programData);
            }
            
            return program;
        }

        public void SaveChanges()
        {
            programInfoRepository.SaveChanges();
            programDataRepository.SaveChanges();
        }

        public ProgramViewModel Delete(ProgramViewModel program)
        {
            foreach (var programData in program.PROGRAMS)
            {
                programDataRepository.Delete(programData.ID);
            }
            programInfoRepository.Delete(program.ID);

            return program;
        }

        public ProgramViewModel Delete(int id)
        {
            var program = this.GetById(id);
            foreach (var programData in program.PROGRAMS)
            {
                programDataRepository.Delete(programData.ID);
            }
            programInfoRepository.Delete(program.ID);

            return program;
        }

        public IEnumerable<ProgramViewModel> GetAll()
        {
            var programsData = programDataRepository.GetAll();
            var programsInfo = programInfoRepository.GetAll();

            List<ProgramViewModel> programViewsModel = new List<ProgramViewModel>();
            foreach (var programInfo in programsInfo)
            {
                var programsDataQuery =
                    from program in programsData
                    where program.PROGRAM_ID == programInfo.ID
                    select program;

                programViewsModel.Add(new ProgramViewModel()
                {
                    ID = programInfo.ID,
                    NAME = programInfo.NAME,
                    DESCRIPTION = programInfo.DESCRIPTION,
                    PROGRAMS = programsDataQuery.ToList()
                });
            }

            return programViewsModel;
        }

        public ProgramViewModel GetById(int id)
        {
            var programInfo = programInfoRepository.GetById(id);
            var programsData = programDataRepository.GetAll();

            var programsDataQuery =
                from program in programsData
                where program.PROGRAM_ID == programInfo.ID
                select program;

            var programViewModel = new ProgramViewModel()
            {
                ID = programInfo.ID,
                NAME = programInfo.NAME,
                DESCRIPTION = programInfo.DESCRIPTION,
                PROGRAMS = programsDataQuery.ToList()
            };

            return programViewModel;
        }

        public ProgramViewModel Update(ProgramViewModel program)
        {
            foreach (var programData in program.PROGRAMS)
            {
                programDataRepository.Update(programData);
            }

            var programInfo = new ProgramInfo()
            {
                ID = program.ID,
                NAME = program.NAME,
                DESCRIPTION = program.DESCRIPTION
            };
            programInfoRepository.Update(programInfo);

            return program;
        }

        public int GetLastProgramID()
        {
            var programInfo = programInfoRepository.GetAll();
            return programInfo.Max(x => x.ID);
        }
    }
}
