using System;
using System.ComponentModel.DataAnnotations;

namespace ZebraPrinter.Entity
{
  [Serializable]
  public class PatientEntity: BaseEntity
  {
    [Required]
    [StringLength(255)]
    public string Name { get; set; }
    [Required]
    [StringLength(255)]
    public string Department { get; set; }
    [Required]
    [StringLength(255)]
    public string BedNumber { get; set; }
  }
}
