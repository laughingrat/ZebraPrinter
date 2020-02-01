using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZebraPrinter.Entity
{
  public class BaseSearchEntity
  {
    public string Keyword { get; set; }
    public string OrderBy { get; set; }

    public string Order { get; set; }

    public BaseSearchEntity()
    {
      Order = "DESC";
      OrderBy = "ID";
    }
  }
}
