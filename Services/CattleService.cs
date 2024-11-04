using BussinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public enum CattleStatus
    {
        REMOVED,
        AVAILABLE
    }

    public class CattleService
    {
        private UnitOfWork unitOfWork;
        private CattleService()
        {
            unitOfWork = new UnitOfWork();
        }

        private static CattleService _instance;
        public static CattleService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CattleService();
            }

            return _instance;
        }

        public Cattle GetCattleById(int id)
        {
            return this.unitOfWork.CattleRepository.GetById(id);
        }

        public List<Cattle> GetCattles()
        {
            return this.unitOfWork.CattleRepository.Get(c => c.Status == true).ToList();
        }

        public void AddNewCattle(Cattle cattle)
        {
            this.unitOfWork.CattleRepository.Insert(cattle);
            this.unitOfWork.SaveChanges();
        }

        public void EditCattle(Cattle cattle)
        {
            this.unitOfWork.CattleRepository.Update(cattle);
            this.unitOfWork.SaveChanges();
        }

        public void RemoveCattle(Cattle cattle)
        {
            cattle.Status = false;
            this.unitOfWork.CattleRepository.Update(cattle);
            this.unitOfWork.SaveChanges();
        }
    }
}
