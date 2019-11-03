using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using pallet_system.DAL;
using pallet_system.Interfaces;
using pallet_system.Manager;
using pallet_system.Models;
using pallet_system.ViewModels;

namespace pallet_system.Controllers
{
    /// <summary>
    /// Pallet manager controller for creating, editing and removing pallets
    /// </summary>
    public class PalletController : Controller
    {
        private readonly PalletManager palletManager;
        private readonly StatusManager statusManager;
        private readonly PalletSystemContext palletSystemContext;

        public PalletController(IRepository<Pallet> palletRepository,
                                IRepository<VirtualPallet> virtualPalletRepository,
                                IRepository<Status> statusRepository,
                                PalletSystemContext palletSystemContext)
        {
            palletManager = new PalletManager(palletRepository, virtualPalletRepository, statusRepository);
            statusManager = new StatusManager(statusRepository);
            this.palletSystemContext = palletSystemContext;
        }

        [Route("")]
        [Route("{Controller}/Index")]
        [Route("{Controller}/List")]
        public IActionResult List()
        {
            var palletViewsModel = palletManager.GetAll();
            return View(palletViewsModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var palletViewModel = palletManager.GetById(id);
            var editPalletViewModel = new EditPalletViewModel()
            {
                STATUSES_INFO = statusManager.GetAll(),
                ID = palletViewModel.ID,
                IP = palletViewModel.IP,
                NAME = palletViewModel.NAME,
                STATUSID = palletViewModel.STATUSID,
                STATUS_NAME = palletViewModel.STATUS_NAME
            };

            return View(editPalletViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditPalletViewModel model)
        {
            if (ModelState.IsValid)
            {

                var palletViewModel = new PalletViewModel()
                {
                    ID = model.ID,
                    IP = model.IP,
                    NAME = model.NAME,
                    STATUSID = statusManager.GetAll().FirstOrDefault(x => x.NAME == model.STATUS_NAME).ID,
                    STATUS_NAME = model.STATUS_NAME
                };

                palletViewModel = palletManager.Update(palletViewModel);
                return RedirectToAction("List");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            palletManager.Delete(id);
            return RedirectToAction("list");
        }

        [HttpGet]
        public IActionResult AddPallet()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPallet(PalletViewModel model)
        {
            if(ModelState.IsValid)
            {
                var createdPallet = palletManager.Add(model);
                return RedirectToAction("List");
            }
            return View(model);
        }


        /// <summary>
        /// Check pallets name uniqeuness
        /// </summary>
        /// <param name="NAME">Name of new pallet</param>
        /// <returns>True if pallet name exist in database</returns>
        [AllowAnonymous]
        [AcceptVerbs("Get", "Post")]
        public JsonResult IsPalletNameExist(string NAME)
        {
            var validateName = palletSystemContext.PALLET.FirstOrDefault(x => x.NAME == NAME);
            if (validateName != null)
                return Json($"Name {NAME} already exist");
            return Json(true);
        }
    }
}