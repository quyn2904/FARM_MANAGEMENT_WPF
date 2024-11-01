using System;
using System.Collections.Generic;

namespace BussinessObjects;

public partial class Cage
{
    public int CageId { get; set; }

    public int? Capacity { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<CattleByCage> CattleByCages { get; set; } = new List<CattleByCage>();

    public virtual ICollection<StaffByCage> StaffByCages { get; set; } = new List<StaffByCage>();
}
