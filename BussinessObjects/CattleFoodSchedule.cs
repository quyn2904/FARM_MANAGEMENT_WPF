using System;
using System.Collections.Generic;

namespace BussinessObjects;

public partial class CattleFoodSchedule
{
    public int ScheduleId { get; set; }

    public int CattleId { get; set; }

    public int FoodId { get; set; }

    public string? FeedingTime { get; set; }

    public int? Quantity { get; set; }

    public virtual Cattle? Cattle { get; set; }

    public virtual Food? Food { get; set; }
}
