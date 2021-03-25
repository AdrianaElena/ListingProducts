using Microsoft.AspNetCore.Mvc;
using Products.Models;
using Products.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Description;

namespace Products.Controllers
{
    [ApiController]
    [Route("api/")]
    public class ProductsControllerApi : ControllerBase
    {
        ProductsDAO repository;

        public ProductsControllerApi()
        {
            repository = new ProductsDAO();
        }

        [HttpGet]
        [ResponseType(typeof(List<ProductModelDTO>))]
        public IEnumerable<ProductModelDTO> Index()
        {
            List<ProductModel> products = repository.GetAllProducts();
            //List<ProductModelDTO> productDTOs = new List<ProductModelDTO>();

            //foreach(var item in products)
            //{
            //    productDTOs.Add(new ProductModelDTO(item));
            //}

            IEnumerable<ProductModelDTO> prodDTOs = from p in products select new ProductModelDTO(p);

            return prodDTOs;
        }


        [HttpGet("searchproducts/{searchTerm}")]
        public ActionResult <IEnumerable<ProductModel>> SearchResults(string searchTerm)
        {
            List<ProductModel> productsList = repository.SearchProducts(searchTerm);

            return productsList;
        }

        [HttpGet("details/{Id}")]
        public ActionResult <ProductModelDTO> ShowDetails(int id)
        {
            ProductModel p = repository.GetProductById(id);

            ProductModelDTO pDTO = new ProductModelDTO(p);

            return pDTO;
        }

        [HttpPost("insert")]
        // post action
        // expecting a product in json format in the body of the request
        public ActionResult <int> Insert(ProductModel product)
        {
            int newId = repository.Insert(product);
            return newId;
        }

        [HttpPut("update")]
        // put request -> for update
        // expect a json formatted object in the body of the request
        // id number must match the item being modified
        public ActionResult <ProductModel> ProcessEdit(ProductModel product)
        {
            repository.Update(product);
            return repository.GetProductById(product.Id);
        }


        [HttpDelete("delete/{Id}")]
        public ActionResult <int> Delete(int id)
        {
            ProductModel product = repository.GetProductById(id);
            int success = repository.Delete(product);
            return success;
        }

    }
}
