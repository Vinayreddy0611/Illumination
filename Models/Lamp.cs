using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Illumination.Models;

public class Lamp
{
    public int Id { get; set; }
    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string? LampType { get; set; }
    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string? Size { get; set; }
    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string? Design { get; set; }
    [Range(1, 100)]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }
    [StringLength(60, MinimumLength = 10)]
    [Required]
    public string? Powersource { get; set; }
}