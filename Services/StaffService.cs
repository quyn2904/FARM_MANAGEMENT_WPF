using BussinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class StaffService
    {
        private StaffService()
        {
        }

        private static StaffService _instance;
        public static StaffService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new StaffService();
            }

            return _instance;
        }

        private UnitOfWork unitOfWork = new UnitOfWork();

        public Staff? Login(string email, string password) => this.unitOfWork.StaffRepository.Login(email, password);
    }
}
