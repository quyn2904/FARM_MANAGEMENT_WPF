using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CattleFoodScheduleService
    {
        private CattleFoodScheduleService()
        {
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
    }
}
