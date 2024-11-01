using System;
using System.Collections.Generic;

namespace BussinessObjects;

public partial class StaffByCage
{
    public int StaffByCageId { get; set; }

    public int? CageId { get; set; }

    public int? StaffId { get; set; }

    public DateTime? AssignedDate { get; set; }

    public string WorkingTime { get; set; } = null!;

    public virtual Cage? Cage { get; set; }

    public virtual Staff? Staff { get; set; }
}
