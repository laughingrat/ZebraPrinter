using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZebraPrinter.Entity;
using ZebraPrinter.Utils;
using System.Reflection;
using System.Data;

namespace ZebraPrinter.DAL
{
  public abstract class OperationDao<T, K> : BaseDao
      where T : BaseEntity
      where K : BaseSearchEntity
  {

    protected virtual string TableName { get; set; }

    //private static Dictionary<string, Dictionary<string, Enums.DataType>> cachedProperties = new Dictionary<string, Dictionary<string, Enums.DataType>>();

    //private Dictionary<string, Enums.DataType> GetProperties<T>(T entity) {
    //  var type = entity.GetType();
    //  var typeName = type.FullName;

    //  if (cachedProperties.ContainsKey(typeName))
    //  {
    //    return cachedProperties[typeName];
    //  }

    //  var properties = type.GetProperties(BindingFlags.Public);
    //  var dic = new Dictionary<string, Enums.DataType>();
    //  foreach (var property in properties) {
    //    if (property.CanRead && property.CanWrite) {
    //      if (property.DeclaringType.IsValueType)
    //      {
    //        if (property.DeclaringType is string) {

    //        }
    //      }
    //    }
    //  }

    //  cachedProperties[typeName] = dic;

    //  return dic;
    //}

    //private string GetTableName<T>(T entity) {
    //  return entity.GetType().Name;
    //}

    public virtual T Create(T entity)
    {
      throw new NotImplementedException();
    }

    public virtual bool Update(T entity)
    {
      throw new NotImplementedException();
    }

    public virtual bool Delete(int id)
    {
      var sb = new StringBuilder();
      sb.Append("DELETE FROM " + TableName + " WHERE ID = " + id.ToString());
      return ExecuteNonQuery(sb.ToString()) > 0;
    }

    public virtual T Retrieve(int id)
    {
      var sb = new StringBuilder();
      sb.Append("SELECT * FROM "+ TableName +" WHERE ID = " + id.ToString());
      var dt = ExecuteTable(sb.ToString());
      if (dt.Rows.Count == 1)
      {
        return Mapping(dt.Rows[0]);
      }

      return null;
    }

    public virtual List<T> All()
    {
      var sb = new StringBuilder();
      sb.Append("SELECT * FROM " + TableName + " ORDER BY updatedon DESC");
      var dt = ExecuteTable(sb.ToString());
      var list = new List<T>();

      foreach (DataRow row in dt.Rows)
      {
        list.Add(Mapping(row));
      }

      return list;
    }

    public virtual List<T> Search(List<int> ids)
    {
      var strIds = string.Join(",", ids);
      var sb = new StringBuilder();
      sb.Append("SELECT * FROM " + TableName + " WHERE id in ("+ strIds + ") ORDER BY updatedon DESC");
      var dt = ExecuteTable(sb.ToString());
      var list = new List<T>();

      foreach (DataRow row in dt.Rows)
      {
        list.Add(Mapping(row));
      }

      return list;
    }

    public virtual List<T> Search(K search)
    {
      throw new NotImplementedException();
    }

    protected virtual T Mapping(DataRow datarow)
    {
      throw new NotImplementedException();
    }

    public virtual bool DeleteAll() {
      var sb = new StringBuilder();
      sb.Append("DELETE FROM " + TableName + " WHERE ID > 0 ");
      return ExecuteNonQuery(sb.ToString()) > 0;
    }
  }
}
