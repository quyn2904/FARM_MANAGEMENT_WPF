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
        }

        private static FoodService _instance;
        public static FoodService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new FoodService();
            }

            return _instance;
        }
    }
}
