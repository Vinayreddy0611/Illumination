using System.ComponentModel.DataAnnotations;
namespace Illumination.Models;

public class Lamp
{
    public int Id { get; set; }
    public string? LampType { get; set; }
    public string? Genre { get; set; }
    public decimal Price { get; set; }
}