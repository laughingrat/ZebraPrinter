using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using ZebraPrinter.Entity;
using ZebraPrinter.Utils;

namespace ZebraPrinter.DAL
{
  public class BaseDao
  {
 

    private OleDbConnection connection;

    private OleDbConnection GetDbConnection() {
      if (connection == null) {
        connection = new OleDbConnection(ConfigHelper.ConnectionString);
      }

      return connection;
    }

    protected long ExecuteNonQuery(string sql, List<OleDbParameterEntity> parameters = null) {
      var connection = GetDbConnection();
      var command = new OleDbCommand();
      command.CommandText = sql;
      command.Connection = connection;
      command.Parameters.AddRange(BuildParameters(parameters));

      connection.Open();
      var affectCount = command.ExecuteNonQuery();
      connection.Close();
      return affectCount;
    }

    protected object ExecuteScalar(string sql, List<OleDbParameterEntity> parameters = null) {
      var connection = GetDbConnection();
      var command = new OleDbCommand();
      command.CommandText = sql;
      command.Connection = connection;
      command.Parameters.AddRange(BuildParameters(parameters));

      connection.Open();
      var result = command.ExecuteScalar();
      connection.Close();
      return result;
    }

    protected OleDbDataReader ExecuteReader(string sql)
    {
      var connection = GetDbConnection();
      var command = new OleDbCommand(sql, connection);
      return command.ExecuteReader();
    }

    protected DataTable ExecuteTable(string sql, List<OleDbParameterEntity> parameters = null) {
      var connection = GetDbConnection();
      var oleAdapter = new OleDbDataAdapter(sql, connection);
      oleAdapter.SelectCommand.Parameters.AddRange(BuildParameters(parameters));
     
      var ds = new DataSet();
       oleAdapter.Fill(ds);
      if (ds.Tables.Count > 0) {
        return ds.Tables[0];
      }

      return null;
    }

    private OleDbParameter[] BuildParameters(List<OleDbParameterEntity> parameters)
    {
      if (parameters == null || parameters.Count == 0)
        return new OleDbParameter[0];

      var arrParam = new OleDbParameter[parameters.Count];
      for (var i = 0; i < parameters.Count; i++)
      {
        var param = parameters[i];
        arrParam[i] = new OleDbParameter(param.Name, param.Type);
        arrParam[i].Value = param.Value;
      }

      return arrParam;
    }
  }
}
