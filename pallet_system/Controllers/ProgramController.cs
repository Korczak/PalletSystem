using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pallet_system.DAL;
using pallet_system.Interfaces;
using pallet_system.Manager;
using pallet_system.Models;
using pallet_system.ViewModels;

namespace pallet_system.Controllers
{
    /// <summary>
    /// Program controller for creating, editing and removing programs
    /// </summary>
    public class ProgramController : Controller
    {
        private readonly ProgramManager programManager;
        private readonly PalletSystemContext palletSystemContext;

        public ProgramController(IRepository<ProgramData> programDataRepository,
                                 IRepository<ProgramInfo> programInfoRepository,
                                 PalletSystemContext palletSystemContext)
        {
            programManager = new ProgramManager(programDataRepository, programInfoRepository);
            this.palletSystemContext = palletSystemContext;
        }

        public IActionResult List()
        {
            var programViewsModel = programManager.GetAll();
            return View(programViewsModel);
        }

        public IActionResult Details(int? id)
        {
            var programViewModel = programManager.GetById(id ?? 1);
            return View(programViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var programViewModel = programManager.GetById(id);
            return View(programViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ProgramViewModel model)
        {
            if (ModelState.IsValid)
            {
                var programViewModel = programManager.Update(model);
                return RedirectToAction("details", new { id = programViewModel.ID });
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            programManager.Delete(id);
            return RedirectToAction("list");
        }

        [HttpGet]
        public IActionResult CreateProgram()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProgram(CreateProgramViewModel model)
        {
            if(ModelState.IsValid)
            {
                model = programManager.AddProgramInfo(model);
                var programs = new List<ProgramData>();
                programs.Add(null);
                var program = new ProgramViewModel()
                {
                    ID = model.ID,
                    NAME = model.NAME,
                    DESCRIPTION = model.DESCRIPTION,
                    PROGRAMS = programs
                };
                return View("CreateProgramSteps", program);
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult CreateProgramSteps(ProgramViewModel model)
        {
            ModelState.Clear();
            model.PROGRAMS.Add(null);
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ProgramViewModel model)
        {
            if(ModelState.IsValid)
            {
                var createdProgram = programManager.AddProgramData(model);
                return RedirectToAction("details", new { id = createdProgram.ID });
            }
            return View("CreateProgram", model);
        }

        [AllowAnonymous]
        [AcceptVerbs("Get", "Post")]
        public JsonResult IsProductNameExist(string NAME)
        {
            var validateName = palletSystemContext.PROGRAM_INFO.FirstOrDefault(x => x.NAME == NAME);
            if (validateName != null)
                return Json($"Name {NAME} already exist");
            return Json(true);
        }
    }
}