using E_commerce.Concrete;
using E_commerce.Interface;
using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_commerce.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            IProductRepository productRepository = new ProductRepository();

            var myResult = productRepository.GetProductInfo();

            return View(myResult);
        }

        public ActionResult Create()
        {
            ProductViewModel productViewModel = new ProductViewModel();

            return View(productViewModel);
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel productViewModel)
        {
            IProductRepository productRepository = new ProductRepository();

            var myResult = productRepository.InsertUpdateProduct(productViewModel);

            if (myResult)
            {
                return RedirectToAction("Index");
            }
            return View();
            
        }

        public ActionResult Edit(int productId)
        {
            IProductRepository productRepository = new ProductRepository();

            var myResult = productRepository.GetProductById(productId);

            return View("Create",myResult);
        }

        public ActionResult Delete(int productId)
        {
            IProductRepository productRepository = new ProductRepository();

            var myResult = productRepository.ProductDelete(productId);

            return RedirectToAction("Index");
        }
    }
}