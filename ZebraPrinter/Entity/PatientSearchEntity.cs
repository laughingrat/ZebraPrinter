using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZebraPrinter.Entity
{
  public class PatientSearchEntity : BaseSearchEntity
  {
    public DateTime? BeginDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Department { get; set; }
    public string BedNumber { get; set; }

    public PatientSearchEntity()
    {
      OrderBy = "updatedon";
    }
  }
}
