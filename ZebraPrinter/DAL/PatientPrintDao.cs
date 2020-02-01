using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ZebraPrinter.Entity;
using ZebraPrinter.Utils;
using System.Data.OleDb;

namespace ZebraPrinter.DAL
{
  public class PatientPrintDao: OperationDao<PatientPrintEntity, PatientPrintSearchEntity>
  {
    protected override string TableName { get => "PatientPrint"; set => base.TableName = value; }

    public override PatientPrintEntity Create(PatientPrintEntity entity)
    {
      var sql = "INSERT INTO "+ TableName + @" (patientId, calorie, ml, quantity, unit, printdate, insertedon, updatedon) VALUES(
@patientId, @calorie, @ml, @quantity, @unit, @printdate, @insertedon, @updatedon)
";

      var parameters = new List<OleDbParameterEntity>() { 
      new OleDbParameterEntity("@patientId", OleDbType.Integer, entity.PatientId),
      new OleDbParameterEntity("@calorie", OleDbType.VarWChar, entity.Calorie),
      new OleDbParameterEntity("@ml", OleDbType.VarWChar, entity.ML),
      new OleDbParameterEntity("@quantity", OleDbType.Integer, entity.Quantity),
      new OleDbParameterEntity("@unit", OleDbType.VarWChar, entity.Unit),
      new OleDbParameterEntity("@printdate", OleDbType.Date, entity.PrintDate),
      new OleDbParameterEntity("@insertedon", OleDbType.Date, entity.InsertedOn),
      new OleDbParameterEntity("@updatedon", OleDbType.Date, entity.UpdatedOn),
      };

      var affectCount = ExecuteNonQuery(sql, parameters);
      if (affectCount == 1)
      {
        sql = "SELECT TOP 1 * FROM " + TableName + " WHERE patientId=@patientId AND printdate=@printdate";

        var table = ExecuteTable(sql, new List<OleDbParameterEntity>() {
        new OleDbParameterEntity("@patientId", OleDbType.Integer, entity.PatientId),
        new OleDbParameterEntity("@printdate", OleDbType.Date, entity.PrintDate),
      });

        if (table.Rows.Count == 1)
        {
          return Mapping(table.Rows[0]);
        }
      }

      return null;
    }

    public override bool Update(PatientPrintEntity entity)
    {
      var sql = "UPDATE " + TableName + @" SET
calorie=@calorie,
ml=@ml,
quantity=@quantity,
unit=@unit,
printdate=@printdate,
updatedon=@updatedon
WHERE id=@id
";

      var parameters = new List<OleDbParameterEntity>() {
      new OleDbParameterEntity("@calorie", OleDbType.VarWChar, entity.Calorie),
      new OleDbParameterEntity("@ml", OleDbType.VarWChar, entity.ML),
      new OleDbParameterEntity("@quantity", OleDbType.Integer, entity.Quantity),
      new OleDbParameterEntity("@unit", OleDbType.VarWChar, entity.Unit),
      new OleDbParameterEntity("@printdate", OleDbType.Date, entity.PrintDate),
      new OleDbParameterEntity("@updatedon", OleDbType.Date, entity.UpdatedOn),
      new OleDbParameterEntity("@id", OleDbType.Integer, entity.Id),
      };

      var affectCount = ExecuteNonQuery(sql, parameters);
      return affectCount == 1;
    }

    protected override PatientPrintEntity Mapping(DataRow datarow)
    {
      var entity = new PatientPrintEntity
      {
        Id = Convert.ToInt32(datarow["ID"]),
        Calorie = datarow["Calorie"].ToString(),
        PatientId = ConvertHelper.ConvertToInt(datarow["patientid"], 0),
        ML = datarow["ml"].ToString(),
        Quantity = ConvertHelper.ConvertToInt(datarow["quantity"], 0),
        Unit = datarow["unit"].ToString(),
        PrintDate = ConvertHelper.CovertToDateTime(datarow["printdate"]).GetValueOrDefault(DateTime.Now),
        InsertedOn = ConvertHelper.CovertToDateTime(datarow["insertedon"]).GetValueOrDefault(DateTime.Now),
        UpdatedOn = ConvertHelper.CovertToDateTime(datarow["updatedon"]).GetValueOrDefault(DateTime.Now)
      };

      return entity;
    }

    public List<PatientPrintEntity> SearchByPatientId(List<int> patientIds)
    {
      var strIds = string.Join(",", patientIds);
      var sb = new StringBuilder();
      sb.Append("SELECT * FROM " + TableName + " WHERE patientid in (" + strIds + ") ORDER BY patientid");
      var dt = ExecuteTable(sb.ToString());
      var list = new List<PatientPrintEntity>();

      foreach (DataRow row in dt.Rows)
      {
        list.Add(Mapping(row));
      }

      return list;
    }

    public override List<PatientPrintEntity> Search(PatientPrintSearchEntity search)
    {
      return null;
    }
  }
}
