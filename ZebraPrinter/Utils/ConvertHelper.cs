using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZebraPrinter.Utils
{
  public sealed class ConvertHelper
  {
    public static int ConvertToInt(object obj, int defaultValue = 0)
    {
      try
      {
        return Convert.ToInt32(obj);
      }
      catch
      {
        return defaultValue;
      }
    }

    public static DateTime? CovertToDateTime(object obj)
    {
      try
      {
        return Convert.ToDateTime(obj);
      }
      catch
      {
        return null;
      }
    }
  }
}
