#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace ProductCategories.Models;
public class Category
{
    [Key]
    public int CategoryId { get; set; }
    [Required]
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdateAt { get; set; } = DateTime.Now;
    public List<Association> Categorias { get; set; } = new List<Association>();
}