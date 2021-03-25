using Microsoft.AspNetCore.Mvc;
using Products.Models;
using Products.Services;
using System.Collections.Generic;

namespace Products.Controllers
{
    public class ProductsController : Controller
    {
        // ProductsDAO repository;
        // HardCodedSampleDataRepository repository;

        public IProductDataService Repository { get; set; }

        public ProductsController(IProductDataService dataService)
        {
            // repository = new ProductsDAO();
            Repository = dataService;
        }

        public IActionResult Index()
        {
            return View(Repository.GetAllProducts());
        }

        public IActionResult SearchForm()
        {
            return View();
        }

        public IActionResult SearchResults(string searchTerm)
        {

            List<ProductModel> productsList = Repository.SearchProducts(searchTerm);

            return View("index", productsList);
        }

        public IActionResult ShowDetails(int id)
        {
            ProductModel foundProduct = Repository.GetProductById(id);

            return View(foundProduct);
        }

        public IActionResult Edit(int id)
        {
            ProductModel foundProduct = Repository.GetProductById(id);
            return View("ShowEditForm",foundProduct);
        }

        public IActionResult ProcessEdit(ProductModel product)
        {
            Repository.Update(product);
            return View("Index", Repository.GetAllProducts());
        }
        
        public IActionResult Delete(int id)
        {
            ProductModel product = Repository.GetProductById(id);
            Repository.Delete(product);
            return View("Index", Repository.GetAllProducts());
        }

        public IActionResult CreateForm()
        {
            return View();
        }

        public IActionResult ProcessCreate(ProductModel product)
        {
            Repository.Insert(product);
            return View("Index", Repository.GetAllProducts());
        }
    }
}
