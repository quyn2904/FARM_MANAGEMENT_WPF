using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CattleDrugService
    {
        private CattleDrugService()
        {
        }

        private static CattleDrugService _instance;
        public static CattleDrugService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CattleDrugService();
            }

            return _instance;
        }
    }
}
