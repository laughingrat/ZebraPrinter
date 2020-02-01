using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ZebraPrinter.Utils
{
    public class ConfigHelper
    {
        static ConfigHelper() {
            ListPrinter = ConfigurationManager.AppSettings["ListPrinter"];
            ZebraPrinter = ConfigurationManager.AppSettings["ZebraPrinter"];
            ConnectionString = ConfigurationManager.ConnectionStrings["nutrition"].ConnectionString;
        }

        public static string ListPrinter { get; set; }
        public static string ZebraPrinter { get; set; }
        public static string ConnectionString { get; set; }
    }
}
