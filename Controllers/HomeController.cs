using System.Collections.Generic;
using System.Linq;
using BuildingForms.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BuildingForms.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
          //TODO: Implement Realistic Implementation
          return View(ProductRepository.Products);
        }

        [HttpGet]
        public IActionResult Create()
        {
          ViewBag.Categories = new SelectList(new List<string>() {"Telefon", "Tablet", "Hesap Makinesi"});
          return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
          ProductRepository.AddProduct(product);
          return RedirectToAction("Index"); //Direct olarak Index action methodunu çağırdık. Index action methodu Index View'ini çağırdı. Index action methodu view'e listeyi yolluyor.
        }

        [HttpGet]
        public IActionResult Search(string q)
        {
          if (string.IsNullOrWhiteSpace(q))
            return View();

          return View("Index", ProductRepository.Products.Where(i=>i.Name.Contains(q))); //Index view'ini çağırıp listeyi burdan gönderdik. Index action methodunu karıştırmadık.
        }
    }
}