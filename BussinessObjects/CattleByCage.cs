using System;
using System.Collections.Generic;

namespace BussinessObjects;

public partial class CattleByCage
{
    public int CattleByCageId { get; set; }

    public int CattleId { get; set; }

    public int CageId { get; set; }

    public DateTime? StartingTimestamp { get; set; }

    public DateTime? EndingTimestamp { get; set; }

    public virtual Cage Cage { get; set; } = null!;

    public virtual Cattle Cattle { get; set; } = null!;
}
