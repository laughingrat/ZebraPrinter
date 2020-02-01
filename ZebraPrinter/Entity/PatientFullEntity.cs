using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZebraPrinter.Entity
{
  public class PatientFullEntity: PatientEntity
  {
    public List<PatientPrintEntity> Prints { get; set; }

    public PatientFullEntity()
    {
      Prints = new List<PatientPrintEntity>();
    }

    public PatientFullEntity(PatientEntity entity) : this()
    {
      Id = entity.Id;
      Name = entity.Name;
      Department = entity.Department;
      BedNumber = entity.BedNumber;
      InsertedOn = entity.InsertedOn;
      UpdatedOn = entity.UpdatedOn;
    }
  }
}
