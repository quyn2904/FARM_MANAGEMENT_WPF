using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class StaffByCageService
    {
        private StaffByCageService()
        {
        }

        private static StaffByCageService _instance;
        public static StaffByCageService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new StaffByCageService();
            }

            return _instance;
        }
    }
}
