using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ZebraPrinter.Entity
{
  public class BaseEntity
  {
    public int Id { get; set; }

    [Required]
    public DateTime InsertedOn { get; set; }

    [Required]
    public DateTime UpdatedOn { get; set; }
  }
}
