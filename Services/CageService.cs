using BussinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CageService
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private CageService()
        {
        }

        private static CageService _instance;
        public static CageService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CageService();
            }

            return _instance;
        }

        public List<Cage> GetAllCage()
        {
            return this.unitOfWork.CageRepository.Get().ToList();
        }
    }
}
