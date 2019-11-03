using pallet_system.Interfaces;
using pallet_system.Models;
using pallet_system.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pallet_system.Manager
{
    /// <summary>
    /// Manager of pallets that wraps Repositories
    /// </summary>
    public class PalletManager :  IManager<PalletViewModel>
    {
        private readonly IRepository<Pallet> palletRepository;
        private readonly IRepository<VirtualPallet> virtualPalletRepository;
        private readonly IRepository<Status> statusRepository;

        public PalletManager(IRepository<Pallet> palletRepository,
                             IRepository<VirtualPallet> virtualPalletRepository,
                             IRepository<Status> statusRepository)
        {
            this.palletRepository = palletRepository;
            this.virtualPalletRepository = virtualPalletRepository;
            this.statusRepository = statusRepository;
        }

        public PalletViewModel Delete(PalletViewModel model)
        {
            palletRepository.Delete(model.ID);
            return model;
        }

        public PalletViewModel Delete(int id)
        {
            var pallet = this.GetById(id);
            palletRepository.Delete(pallet.ID);
            return pallet;
        }

        public IEnumerable<PalletViewModel> GetAll()
        {
            var pallets = palletRepository.GetAll();
            var status = statusRepository.GetAll();
            List<PalletViewModel> palletViewsModel = new List<PalletViewModel>();

            foreach(var pallet in pallets)
            {
                palletViewsModel.Add(new PalletViewModel()
                {
                    ID = pallet.ID ?? 0,
                    NAME = pallet.NAME,
                    IP = pallet.IP,
                    STATUSID = pallet.STATUS ?? 3,
                    STATUS_NAME = status.FirstOrDefault(x => x.ID == pallet.STATUS).NAME
                });
            }

            return palletViewsModel;
        }

        public PalletViewModel GetById(int id)
        {
            var pallet = palletRepository.GetById(id);
            var status = statusRepository.GetAll();

            var palletViewModel = new PalletViewModel()
            {
                ID = pallet.ID ?? 0,
                NAME = pallet.NAME,
                IP = pallet.IP,
                STATUSID = pallet.STATUS ?? 3,
                STATUS_NAME = status.FirstOrDefault(x => x.ID == pallet.STATUS).NAME
            };

            return palletViewModel;
        }

        public PalletViewModel Update(PalletViewModel model)
        {
            var pallet = new Pallet()
            {
                ID = model.ID,
                NAME = model.NAME,
                IP = model.IP,
                STATUS = model.STATUSID
            };

            palletRepository.Update(pallet);
            return model;
        }

        public PalletViewModel Add(PalletViewModel model)
        {
            var pallet = new Pallet()
            {
                IP = model.IP,
                NAME = model.NAME
            };

            pallet = palletRepository.AddAndSave(pallet);
            return model;
        }
    }
}
