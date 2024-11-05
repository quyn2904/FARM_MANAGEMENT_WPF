using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObjects
{
    public class QuantityByCage
    {
        public int CageId { get; set; }
        public int Quantity { get; set; }
    }

    public class CageWithQuantity
    {
        public Cage Cage { get; set; }
        public int Quantity { get; set; }
    }
}
