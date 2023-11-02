#pragma warning disable CS8618
namespace ProductCategories.Models;

public class CategoryViewModel
{
    public Product ProductosA { get; set; } = new Product();
    public Product ProductosFilter { get; set; } = new Product();

    public List<Product> AllProducts { get; set; } = new List<Product>();
    public Category categoriass { get; set; } = new Category();
    public Category CategoriaFilter { get; set; } = new Category();
    public Association newAssociation { get; set; } = new Association();
}