using BussinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CattleFoodScheduleService
    {
        private UnitOfWork unitOfWork;
        private CattleFoodScheduleService()
        {
            this.unitOfWork = new UnitOfWork();
        }

        private static CattleFoodScheduleService _instance;
        public static CattleFoodScheduleService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CattleFoodScheduleService();
            }

            return _instance;
        }

        public List<CattleFoodSchedule> GetFeedingHistory (int cattleId)
        {
            return this.unitOfWork.CattleFoodScheduleRepository.Get(item => item.CattleId == cattleId).ToList();
        }

        public void AddFeedingHistory(CattleFoodSchedule foodSchedule)
        {
            this.unitOfWork.CattleFoodScheduleRepository.Insert(foodSchedule);
            var food = this.unitOfWork.FoodRepository.GetById(foodSchedule.FoodId);
            food.Quantity -= foodSchedule.Quantity;
            this.unitOfWork.FoodRepository.Update(food);
            this.unitOfWork.SaveChanges();
        }
    }
}
