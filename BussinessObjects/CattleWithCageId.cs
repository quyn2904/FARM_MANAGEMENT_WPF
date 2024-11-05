using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObjects
{
    public class CattleWithCageId
    {
        public int CattleId { get; set; }

        public int? Age { get; set; }

        public decimal? Weight { get; set; }

        public string? HealthStatus { get; set; }

        public bool? Status { get; set; }

        public int CageId { get; set; }
    }
}
