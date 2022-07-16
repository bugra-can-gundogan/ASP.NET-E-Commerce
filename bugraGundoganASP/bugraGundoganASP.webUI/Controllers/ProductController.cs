using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using bugraGundoganASP.entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using bugraGundoganASP.data.Abstract;

namespace bugraGundoganASP.webUI.Controllers
{
    public class ProductController:Controller
    {

        public IActionResult Index()
        {
            var product = new Product {Name="Iphone X",Price=6000,Description="güzel telefon"};

            // ViewData["Category"] = "Telefonlar";
            // ViewData["Product"] = product;

            ViewBag.Category = "Telefonlar";
            // ViewBag.Product = product;

            // ViewBag.Product
            return View(product);
        }
        public IActionResult list(int? id, string q) 
        {
            //var products = ProductRepository.Products;

            //if (id != null) { 
            
            //    products = products.Where(p=>p.CategoryId == id).ToList();
            //}

            //if (!string.IsNullOrEmpty(q)) { 
            //    products = products.Where(p=>p.Name.ToLower().Contains(q.ToLower()) || p.Description.ToLower().Contains(q.ToLower())).ToList();
            
            //}

            //var productViewModel = new ProductViewModel()
            //{
            //    Products = products
            //};

            return View();
        }

        public IActionResult Details(int id)
        {
            return View();
        }

        public IActionResult Create()
        {
            //ViewBag.Categories = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(CategoryRepository.Categories, "CategoryId","Name");
            return View(new Product());
        }

        [HttpPost]
        public IActionResult Create(Product p)
        {
            //if (ModelState.IsValid) {
            //    ProductRepository.AddProduct(p);
            //    return RedirectToAction("list");
            //}
            
            //ViewBag.Categories = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(CategoryRepository.Categories, "CategoryId", "Name");
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //ViewBag.Categories = new SelectList(CategoryRepository.Categories, "CategoryId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Product p)
        {
            //ProductRepository.EditProduct(p);
            return RedirectToAction("list");
        }

        [HttpPost]
        public IActionResult Delete(int ProductId)
        {
            //ProductRepository.DeleteProduct(ProductId);
            return RedirectToAction("list");
        }
    }
}