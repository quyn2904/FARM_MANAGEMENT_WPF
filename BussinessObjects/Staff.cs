using System;
using System.Collections.Generic;

namespace BussinessObjects;

public partial class Staff
{
    public int StaffId { get; set; }

    public string? Name { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? Position { get; set; }

    public string Password { get; set; } = null!;

    public virtual ICollection<StaffByCage> StaffByCages { get; set; } = new List<StaffByCage>();
}
