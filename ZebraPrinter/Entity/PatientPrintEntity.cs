using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace ZebraPrinter.Entity
{
  public class PatientPrintEntity: BaseEntity
  {
    [Required]
    public int PatientId { get; set; }
    [StringLength(10)]
    public string Calorie { get; set; }
    [StringLength(10)]
    public string ML { get; set; }
    [Required]
    public int Quantity { get; set; }
    [Required]
    [StringLength(10)]
    public string Unit { get; set; }
    [Required]
    public DateTime PrintDate { get; set; }

    [JsonIgnore]
    public PatientEntity Patient { get; set; }
  }
}
