using System.Data.OleDb;

namespace ZebraPrinter.Entity
{
  public class OleDbParameterEntity
  {
    public string Name { get; set; }

    public OleDbType Type { get; set; }

    public object Value { get; set; }

    public OleDbParameterEntity(string name, OleDbType type, object value)
    {
      Name = name;
      Type = type;
      Value = value;
    }
  }
}
