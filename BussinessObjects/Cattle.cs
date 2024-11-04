using System;
using System.Collections.Generic;

namespace BussinessObjects;

public partial class Cattle
{
    public int CattleId { get; set; }

    public int? Age { get; set; }

    public decimal? Weight { get; set; }

    public string? HealthStatus { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<CattleByCage> CattleByCages { get; set; } = new List<CattleByCage>();

    public virtual ICollection<CattleDrug> CattleDrugs { get; set; } = new List<CattleDrug>();

    public virtual ICollection<CattleFoodSchedule> CattleFoodSchedules { get; set; } = new List<CattleFoodSchedule>();
}
