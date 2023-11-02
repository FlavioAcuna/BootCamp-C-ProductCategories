using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCategories.Models;

namespace ProductCategories.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;
    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        ViewBag.ListProd = _context.Products.ToList();
        return View();
    }

    [HttpGet("product/{ProdId}")]
    public IActionResult OneProd(int ProdId)
    {
        ViewBag.ListProd = _context.Products.Where(prod => prod.ProductId == ProdId).FirstOrDefault();
        ViewBag.LisCat = _context.Categories.ToList();
        CategoryViewModel catviewmodel = new CategoryViewModel
        {
            newAssociation = new Association(),
            ProductosA = _context.Products.Include(p => p.Productos).ThenInclude(c => c.Category).FirstOrDefault(c => c.ProductId == ProdId)
        };

        return View("Product", catviewmodel);
    }

    [HttpPost("")]
    public IActionResult AddProduct(Product Newproduct)
    {
        ViewBag.ListProd = _context.Products.ToList();
        if (ModelState.IsValid)
        {
            _context.Add(Newproduct);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View("Index", Newproduct);
        }
    }

    [HttpGet("categories")]
    public IActionResult ViewCategorias()
    {
        ViewBag.ListCat = _context.Categories.ToList();

        return View("Categories");
    }
    [HttpGet("categories/{CatId}")]
    public IActionResult OneCat(int CatId)
    {
        ViewBag.ListCat = _context.Categories.Where(cat => cat.CategoryId == CatId).FirstOrDefault();
        ViewBag.Lispro = _context.Products.ToList();
        CategoryViewModel catviewmodel = new CategoryViewModel
        {
            newAssociation = new Association(),
            categoriass = _context.Categories.Include(categorias => categorias.Categorias).ThenInclude(p => p.Product).FirstOrDefault(c => c.CategoryId == CatId)
        };
        return View("Category", catviewmodel);
    }
    [HttpPost("categories")]
    public IActionResult AddCategory(Category newCategory)
    {
        ViewBag.ListCat = _context.Categories.ToList();
        if (ModelState.IsValid)
        {
            _context.Add(newCategory);
            _context.SaveChanges();
            return RedirectToAction("ViewCategorias");
        }
        else
        {
            return View("Categories", newCategory);
        }
    }

    [HttpPost("categories/{CatId}/create")]
    public IActionResult AddProdOnCad(Association newasso, int CatId, int ProdId)
    {
        ViewBag.ListCat = _context.Categories.Where(cat => cat.CategoryId == CatId).FirstOrDefault();
        CategoryViewModel catviewmodel = new CategoryViewModel
        {
            newAssociation = new Association(),
            categoriass = _context.Categories.Include(categorias => categorias.Categorias).ThenInclude(p => p.Product).FirstOrDefault(c => c.CategoryId == CatId)
        };
        newasso.CategoryId = CatId;
        _context.Add(newasso);
        _context.SaveChanges();
        ViewBag.ListCat = _context.Categories.Where(cat => cat.CategoryId == CatId).FirstOrDefault();
        ViewBag.Lispro = _context.Products.ToList();
        return View("Category", catviewmodel);
    }

    [HttpPost("product/{ProdId}/create")]
    public IActionResult AddCatonProd(Association newasso, int ProdId)
    {
        ViewBag.LisCat = _context.Categories.ToList();
        ViewBag.ListProd = _context.Products.Where(p => p.ProductId == ProdId).FirstOrDefault();
        CategoryViewModel catviewmodel = new CategoryViewModel
        {
            newAssociation = new Association(),
            ProductosA = _context.Products.Include(p => p.Productos).ThenInclude(c => c.Category).FirstOrDefault(c => c.ProductId == ProdId)

        };
        newasso.ProductId = ProdId;
        _context.Add(newasso);
        _context.SaveChanges();
        ViewBag.Lispro = _context.Products.ToList();
        return View("Product", catviewmodel);
    }



    public IActionResult Privacy()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
