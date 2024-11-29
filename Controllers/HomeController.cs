using Microsoft.AspNetCore.Mvc;
using RegisterLoginApp_ASP_MVC.Models;
using System.Collections.Generic;

namespace RegisterLoginApp_ASP_MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Dummy ürün listesi
            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Ürün 1",
                    Description = "Ürün Açıklaması",
                    Price = 99.99m,
                    ImageUrl = "https://cdn.shopify.com/s/files/1/0533/2089/files/placeholder-images-image_large.png?v=1530129081" // Örnek resim URL'si
                },
                new Product
                {
                    Id = 2,
                    Name = "Ürün 2",
                    Description = "Ürün Açıklaması",
                    Price = 49.99m,
                    ImageUrl = "https://cdn.shopify.com/s/files/1/0533/2089/files/placeholder-images-image_large.png?v=1530129081"
                },
                new Product
                {
                    Id = 3,
                    Name = "Ürün 3",
                    Description = "Ürün Açıklaması",
                    Price = 79.99m,
                    ImageUrl = "https://cdn.shopify.com/s/files/1/0533/2089/files/placeholder-images-image_large.png?v=1530129081"
                },
                new Product
                {
                    Id = 4,
                    Name = "Ürün 4",
                    Description = "Ürün Açıklaması",
                    Price = 129.99m,
                    ImageUrl = "https://cdn.shopify.com/s/files/1/0533/2089/files/placeholder-images-image_large.png?v=1530129081"
                }
            };

            return View(products);
        }
    }
}
