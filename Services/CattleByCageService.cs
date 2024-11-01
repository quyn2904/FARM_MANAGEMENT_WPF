using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CattleByCageService
    {
        private CattleByCageService()
        {
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
    }
}
