using BussinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DrugService
    {
        private DrugService()
        {
            this.unitOfWork = new UnitOfWork();
        }

        private UnitOfWork unitOfWork;

        private static DrugService _instance;
        public static DrugService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DrugService();
            }

            return _instance;
        }

        public List<Drug> GetAll()
        {
            return this.unitOfWork.DrugRepository.Get().ToList();
        }

        public void ImportDrug(Drug drug, int quantity)
        {
            drug.Quantity += quantity;
            this.unitOfWork.DrugRepository.Update(drug);
            this.unitOfWork.SaveChanges();
        }

        public void AddNewDrug(Drug drug)
        {
            this.unitOfWork.DrugRepository.Insert(drug);
            this.unitOfWork.SaveChanges();
        }

        public void UpdateDrug(Drug drug)
        {
            this.unitOfWork.DrugRepository.Update(drug);
            this.unitOfWork.SaveChanges();
        }

        public Drug GetDrugById(int id)
        {
            return this.unitOfWork.DrugRepository.GetById(id);
        }

        public Drug GetDrugByName(string name)
        {
            return this.unitOfWork.DrugRepository.GetByName(name);
        }
    }
}
