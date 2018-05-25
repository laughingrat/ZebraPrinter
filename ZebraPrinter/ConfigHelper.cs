using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ZebraPrinter
{
    public class ConfigHelper
    {
        static ConfigHelper() {
            ListPrinter = ConfigurationManager.AppSettings["ListPrinter"];
            ZebraPrinter = ConfigurationManager.AppSettings["ZebraPrinter"];
        }

        public static string ListPrinter { get; set; }
        public static string ZebraPrinter { get; set; }
    }
}
