#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace ProductCategories.Models;

public class Product
{
    [Key]
    public int ProductId { get; set; }
    [Required(ErrorMessage = "Este campo es obligatorio")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Este campo es obligatorio")]
    public string Description { get; set; }
    [Required(ErrorMessage = "Este campo es obligatorio")]
    [Range(0, double.PositiveInfinity, ErrorMessage = "El valor no puede ser negativo")]
    public double Price { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdateAt { get; set; } = DateTime.Now;

    public List<Association> Productos { get; set; } = new List<Association>();
}