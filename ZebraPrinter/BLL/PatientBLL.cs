using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZebraPrinter.DAL;
using ZebraPrinter.Entity;
using ZebraPrinter.Utils;

namespace ZebraPrinter.BLL
{
  public class PatientBLL : BaseBLL<PatientEntity, PatientSearchEntity, PatientDao>
  {
    private PatientPrintBLL printBLL;
    public PatientBLL(PatientPrintBLL printBLL) : base(new PatientDao())
    {
      this.printBLL = printBLL;
    }

    public Dictionary<OldPatientEntity, string> Import(List<OldPatientEntity> oldPatients)
    {
      var dic = new Dictionary<OldPatientEntity, string>();

      if (oldPatients == null || oldPatients.Count == 0)
        return dic;

      foreach (var oldEntity in oldPatients)
      {
        try
        {
          var entity = new PatientEntity
          {
            Name = oldEntity.Name,
            Department = oldEntity.Department,
            BedNumber = oldEntity.Department,
            InsertedOn = oldEntity.InsertedOn,
            UpdatedOn = DateTime.Now
          };

          entity = dao.Create(entity);

          if (!string.IsNullOrWhiteSpace(oldEntity.Calorie))
          {
            var printEntity = new PatientPrintEntity
            {
              PatientId = entity.Id,
              Calorie = oldEntity.Calorie,
              Quantity = oldEntity.Count,
              ML = oldEntity.ML,
              PrintDate = oldEntity.PrintDate,
              Unit = oldEntity.Unit,
              UpdatedOn = DateTime.Now,
              InsertedOn = DateTime.Now
            };

            printBLL.Create(printEntity);
          }

          dic.Add(oldEntity, "");
        }
        catch (Exception ex)
        {
          dic.Add(oldEntity, ex.Message);
        }
      }

      return dic;
    }


    public List<PatientFullEntity> GetTodayPatients()
    {
      var todayPatients = dao.GetTodayPatients();
      var patientIds = todayPatients.Select(tp => tp.Id).ToList();
      if (patientIds == null || patientIds.Count == 0)
        return new List<PatientFullEntity>();

      var prints = printBLL.SearchByPatientId(patientIds);

      var list = todayPatients.Select(tp => new PatientFullEntity
      {
        Id = tp.Id,
        Name = tp.Name,
        Department = tp.Department,
        BedNumber = tp.BedNumber,
        InsertedOn = tp.InsertedOn,
        UpdatedOn = tp.UpdatedOn,
        Prints = prints.Where(p => p.PatientId == tp.Id).OrderBy(p => p.PrintDate).ToList()
      });

      return list.ToList();
    }

    public string Export(List<PatientFullEntity> patientFullEntities)
    {
      if (patientFullEntities.Count > 0)
      {
        var sb = new StringBuilder();

        sb.AppendLine("姓名, 科室, 床号, 配置日期, 热能, 签名");

        foreach (var patient in patientFullEntities)
        {
          var printDate = "";
          var caroli = "";
          if (patient.Prints != null && patient.Prints.Count > 0)
          {
            var lastPrint = patient.Prints.Last();
            printDate = lastPrint.PrintDate.ToString(Consts.DEFAULT_DATE_FORMAT);
            caroli = string.Format("{0}kal/{1}ml * {2}{3}", lastPrint.Calorie, lastPrint.ML, lastPrint.Quantity, lastPrint.Unit);
          }
          sb.AppendLine(string.Format("{0}, {1}, {2}, {3}, {4}, {5}", patient.Name, patient.Department, patient.BedNumber, printDate, caroli, "________________"));
          
        }

        return sb.ToString();
      }

      return string.Empty;
    }
  }
}
