using System;
using System.Collections.Generic;

namespace BussinessObjects;

public partial class Food
{
    public int FoodId { get; set; }

    public string? Name { get; set; }

    public string? Type { get; set; }

    public int? Quantity { get; set; }

    public virtual ICollection<CattleFoodSchedule> CattleFoodSchedules { get; set; } = new List<CattleFoodSchedule>();
}
