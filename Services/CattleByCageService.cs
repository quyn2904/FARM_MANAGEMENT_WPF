using BussinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CattleByCageService
    {
        private UnitOfWork unitOfWork;
        private CattleByCageService()
        {
            this.unitOfWork = new UnitOfWork();
        }

        private static CattleByCageService _instance;
        public static CattleByCageService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CattleByCageService();
            }

            return _instance;
        }

        public void AddNewCattleByCage(CattleByCage cattleByCage)
        {
            this.unitOfWork.CattleByCageRepository.Insert(cattleByCage);
            this.unitOfWork.SaveChanges();
        }

        public List<CattleByCage> FindCattleByCage(int cattleId)
        {
            return this.unitOfWork.CattleByCageRepository.Get(c => c.CattleId == cattleId).ToList();
        }

        public CattleByCage GetDefaultCage(int cattleId)
        {
            return this.unitOfWork.CattleByCageRepository.Get(c => c.CattleId == cattleId && c.EndingTimestamp.Value == null).ToList().FirstOrDefault();
        }

        public CattleByCage GetCurrentCage(int cattleId)
        {
            var cattleByCage = this.unitOfWork.CattleByCageRepository.Get(c => c.CattleId == cattleId && c.StartingTimestamp < DateTime.Now && c.EndingTimestamp > DateTime.Now).FirstOrDefault();
            if (cattleByCage != null)
            {
                return cattleByCage;
            }
            return GetDefaultCage(cattleId);
        }

        public void UpdateCattleByCage(CattleByCage cattleByCage)
        {
            this.unitOfWork.CattleByCageRepository.Update(cattleByCage);
            this.unitOfWork.SaveChanges();
        }

        public List<CattleByCage> GetAllCattleByCages()
        {
            return this.unitOfWork.CattleByCageRepository.Get(c => c.EndingTimestamp.Value == null).ToList();
        }

        public List<QuantityByCage> GetCurrentlyOccupiedCagesForEachCage()
        {
            return this.unitOfWork.CattleByCageRepository.Get(c => c.EndingTimestamp.Value == null).GroupBy(c => c.CageId).Select(g => new QuantityByCage()
            {
                CageId = g.Key,
                Quantity = g.Count()
            }).ToList();
        }

        public bool CheckCageAvailable(int cageId)
        {
            var currentQuantity = this.unitOfWork.CattleByCageRepository.Get(c => c.CageId == cageId && c.EndingTimestamp.Value == null).Count();
            return this.unitOfWork.CageRepository.Get(c => c.CageId == cageId).FirstOrDefault().Capacity > currentQuantity;
        }
    }
}
