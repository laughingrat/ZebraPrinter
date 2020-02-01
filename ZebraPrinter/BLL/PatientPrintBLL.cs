using System;
using System.Collections.Generic;
using ZebraPrinter.DAL;
using ZebraPrinter.Entity;

namespace ZebraPrinter.BLL
{
  public class PatientPrintBLL : BaseBLL<PatientPrintEntity, PatientPrintSearchEntity, PatientPrintDao>
  {
    public PatientPrintBLL() : base(new PatientPrintDao())
    { }

    public List<PatientPrintEntity> SearchByPatientId(List<int> patientIds)
    {
      if (patientIds == null || patientIds.Count == 0)
      {
        return new List<PatientPrintEntity>();
      }

      return dao.SearchByPatientId(patientIds);
    }
  }
}
