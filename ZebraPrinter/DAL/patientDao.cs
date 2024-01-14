using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;
using ZebraPrinter.Entity;
using ZebraPrinter.Utils;

namespace ZebraPrinter.DAL
{
  public class PatientDao : OperationDao<PatientEntity, PatientSearchEntity>
  {

    protected override string TableName { get => "Patient"; set => base.TableName = value; }
    public override PatientEntity Create(PatientEntity entity)
    {
      var sql = "INSERT INTO " + TableName + " (fullname, department, bednumber, caseid, insertedon, updatedon) " +
        "VALUES(@fullname, @department, @bednumber, @caseid, @insertedon, @updatedon)";

      var parameters = new List<OleDbParameterEntity>() {
      new OleDbParameterEntity("@fullname", OleDbType.VarWChar, entity.Name),
      new OleDbParameterEntity("@department", OleDbType.VarWChar, entity.Department),
      new OleDbParameterEntity("@bednumber", OleDbType.VarWChar, entity.BedNumber),
      new OleDbParameterEntity("@caseid", OleDbType.VarWChar, entity.CaseId),
      new OleDbParameterEntity("@insertedon", OleDbType.Date, entity.InsertedOn),
      new OleDbParameterEntity("@updatedon", OleDbType.Date, entity.UpdatedOn)
      };

      var affectCount = ExecuteNonQuery(sql, parameters);
      if (affectCount == 1)
      {
        sql = "SELECT TOP 1 * FROM " + TableName + " WHERE fullname=@fullname AND department=@department AND bednumber=@bednumber AND caseid=@caseid  AND insertedon=@insertedon";

        var table = ExecuteTable(sql, parameters);

        if (table.Rows.Count == 1)
        {
          return Mapping(table.Rows[0]);
        }
      }

      return null;
    }

    public override bool Update(PatientEntity entity)
    {
      var sb = new StringBuilder();
      sb.Append("UPDATE Patient SET ");
      sb.Append(" fullname=@fullname,");
      sb.Append(" department=@department,");
      sb.Append(" bednumber=@bednumber,");
      sb.Append(" caseid=@caseid,");
      sb.Append(" updatedon=@updatedon ");
      sb.Append(" WHERE id=@id");

      var parameters = new List<OleDbParameterEntity>() {
      new OleDbParameterEntity("@fullname", OleDbType.VarWChar, entity.Name),
      new OleDbParameterEntity("@department", OleDbType.VarWChar, entity.Department),
      new OleDbParameterEntity("@bednumber", OleDbType.VarWChar, entity.BedNumber),
      new OleDbParameterEntity("@caseid", OleDbType.VarWChar, entity.CaseId),
      new OleDbParameterEntity("@updatedon", OleDbType.Date, entity.UpdatedOn),
      new OleDbParameterEntity("@id", OleDbType.Integer, entity.Id)
      };

      var affectCount = ExecuteNonQuery(sb.ToString(), parameters);
      return affectCount == 1;
    }

    protected override PatientEntity Mapping(DataRow datarow)
    {
      var entity = new PatientEntity
      {
        Id = Convert.ToInt32(datarow["ID"]),
        Name = datarow["fullName"].ToString(),
        BedNumber = datarow["bednumber"].ToString(),
        Department = datarow["department"].ToString(),
        CaseId = datarow["caseid"].ToString(),
        InsertedOn = ConvertHelper.CovertToDateTime(datarow["insertedon"]).GetValueOrDefault(DateTime.Now),
        UpdatedOn = ConvertHelper.CovertToDateTime(datarow["updatedon"]).GetValueOrDefault(DateTime.Now)
      };

      return entity;
    }

    public List<PatientEntity> GetTodayPatients()
    {
      var sql = @" 
SELECT p.*
FROM patient p
WHERE p.updatedon >= @today OR EXISTS(SELECT 1 FROM patientprint pp WHERE pp.printdate > @today AND p.id = pp.patientId)
ORDER BY p.department, p.fullname, p.bednumber
";
      var parameters = new List<OleDbParameterEntity>() {
      new OleDbParameterEntity("@today", OleDbType.Date, DateTime.Now.Date)
      };
      var table = ExecuteTable(sql, parameters);
      var list = new List<PatientEntity>();

      foreach (DataRow dataRow in table.Rows)
      {
        var entity = Mapping(dataRow);
        list.Add(entity);
      }

      return list;
    }

    public override List<PatientEntity> Search(PatientSearchEntity search)
    {
      var sb = new StringBuilder();
      var parameters = new List<OleDbParameterEntity>();

      sb.Append("SELECT * FROM " + TableName + " WHERE 1=1 ");
      if (search.BeginDate.HasValue)
      {
        sb.Append(" AND updatedon >= @begindate ");
        parameters.Add(new OleDbParameterEntity("@begindate", OleDbType.Date, search.BeginDate.Value));
      }
      if (search.EndDate.HasValue)
      {
        sb.Append(" AND updatedon <= @enddate ");
        parameters.Add(new OleDbParameterEntity("@enddate", OleDbType.Date, search.EndDate.Value));
      }

      if (!string.IsNullOrWhiteSpace(search.Department))
      {
        sb.Append(" AND department= @department ");
        parameters.Add(new OleDbParameterEntity("@department", OleDbType.VarWChar, search.Department));
      }

      if (!string.IsNullOrWhiteSpace(search.BedNumber))
      {
        sb.Append(" AND bednumber=@bednumber ");
        parameters.Add(new OleDbParameterEntity("@bednumber", OleDbType.VarWChar, search.BedNumber));
      }

      if (!string.IsNullOrWhiteSpace(search.Keyword))
      {
        sb.Append(" AND fullname like '%' + @Keyword +'%' ");
        parameters.Add(new OleDbParameterEntity("@Keyword", OleDbType.VarWChar, search.Keyword));
      }

      if (!string.IsNullOrWhiteSpace(search.OrderBy))
      {
        sb.Append(" ORDER BY " + search.OrderBy);
      }
      else
      {
        sb.Append(" ORDER BY updatedon desc");
      }

      var table = ExecuteTable(sb.ToString(), parameters);
      var list = new List<PatientEntity>();
      foreach (DataRow row in table.Rows)
      {
        list.Add(Mapping(row));
      }

      return list;
    }
  }
}
