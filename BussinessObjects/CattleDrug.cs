using System;
using System.Collections.Generic;

namespace BussinessObjects;

public partial class CattleDrug
{
    public int CattleDrugId { get; set; }

    public int? CattleId { get; set; }

    public int? DrugId { get; set; }

    public string? Dosage { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual Cattle? Cattle { get; set; }

    public virtual Drug? Drug { get; set; }
}
