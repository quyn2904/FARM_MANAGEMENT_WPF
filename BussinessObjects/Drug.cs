using System;
using System.Collections.Generic;

namespace BussinessObjects;

public partial class Drug
{
    public int DrugId { get; set; }

    public string? Name { get; set; }

    public string? Type { get; set; }

    public int? Quantity { get; set; }

    public string? UsageInstructions { get; set; }

    public virtual ICollection<CattleDrug> CattleDrugs { get; set; } = new List<CattleDrug>();
}
