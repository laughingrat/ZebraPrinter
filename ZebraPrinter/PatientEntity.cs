using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZebraPrinter
{
    [Serializable]
    public class PatientEntity : BasePatientEntity
    {
        public PatientEntity()
        {
        }

        public string Calorie { get; set; }
        public string ML { get; set; }
        public int Count { get; set; }
        public DateTime PrintDate { get; set; }
        public string Unit { get; set; }
    }

    public class BasePatientEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string BedNumber { get; set; }
        public DateTime InsertedOn { get; set; }
    }
}
