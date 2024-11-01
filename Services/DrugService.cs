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
        }

        private static DrugService _instance;
        public static DrugService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DrugService();
            }

            return _instance;
        }
    }
}
