using System.ComponentModel.DataAnnotations;

namespace ProductCategories.Models;
public class Association
{
    [Key]
    public int AssociationId { get; set; }

    public int ProductId { get; set; }

    public int CategoryId { get; set; }
    //Propiedas de navegacion !!No olvidar el ?
    public Product? Product { get; set; }
    public Category? Category { get; set; }
}