using BussinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class FoodService
    {
        private FoodService()
        {
            this.unitOfWork = new UnitOfWork();
        }

        private UnitOfWork unitOfWork;

        private static FoodService _instance;
        public static FoodService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new FoodService();
            }

            return _instance;
        }

        public List<Food> GetAll()
        {
            return this.unitOfWork.FoodRepository.Get().ToList();
        }

        public void ImportFood(Food food, int quantity)
        {
            food.Quantity += quantity;
            this.unitOfWork.FoodRepository.Update(food);
            this.unitOfWork.SaveChanges();
        }

        public void AddNewFood(Food food)
        {
            this.unitOfWork.FoodRepository.Insert(food);
            this.unitOfWork.SaveChanges();
        }

        public void UpdateFood(Food food)
        {
            this.unitOfWork.FoodRepository.Update(food);
            this.unitOfWork.SaveChanges();
        }

        public Food GetFoodById(int id) 
        {
            return this.unitOfWork.FoodRepository.GetById(id);
        }

        public Food GetFoodByName (string name)
        {
            return this.unitOfWork.FoodRepository.GetByName(name);
        }
    }
}
