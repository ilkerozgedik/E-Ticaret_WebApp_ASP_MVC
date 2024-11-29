using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegisterLoginApp_ASP_MVC.Models;
using RegisterLoginApp_ASP_MVC.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace RegisterLoginApp_ASP_MVC.Controllers
{
    public class CartController : Controller
    {
        // Sabit ürün listesi
        private static readonly List<Product> Products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Ürün 1",
                Description = "Ürün Açıklaması",
                Price = 99.99m,
                ImageUrl = "https://cdn.shopify.com/s/files/1/0533/2089/files/placeholder-images-image_large.png?v=1530129081"
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

        // Sepete ürün ekleme
        public IActionResult AddToCart(int productId)
        {
            var product = Products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                return NotFound();
            }

            var cart = HttpContext.Session.GetObjectFromJson<List<ProductInCart>>("Cart") ?? new List<ProductInCart>();

            var existingProduct = cart.FirstOrDefault(p => p.Id == product.Id);

            if (existingProduct != null)
            {
                existingProduct.Quantity++;
            }
            else
            {
                cart.Add(new ProductInCart
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    ImageUrl = product.ImageUrl,
                    Quantity = 1
                });
            }

            // Sepeti session'a kaydediyoruz
            HttpContext.Session.SetObjectAsJson("Cart", cart);

            // Sepet sayısını ViewBag'e ekliyoruz
            ViewBag.CartCount = cart.Sum(p => p.Quantity);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult ViewCart()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<ProductInCart>>("Cart") ?? new List<ProductInCart>();

            // Sepet sayısını ViewBag'e ekliyoruz
            ViewBag.CartCount = cart.Sum(p => p.Quantity);

            return View(cart);
        }

        // Sepetten ürün çıkarma
        public IActionResult RemoveFromCart(int productId)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<ProductInCart>>("Cart") ?? new List<ProductInCart>();

            var productToRemove = cart.FirstOrDefault(p => p.Id == productId);

            if (productToRemove != null)
            {
                cart.Remove(productToRemove); // Ürünü sepetten çıkar
            }

            HttpContext.Session.SetObjectAsJson("Cart", cart);
            ViewBag.CartCount = cart.Sum(p => p.Quantity); // Sepet sayısını güncelle
            return RedirectToAction("ViewCart");
        }
    }
}
