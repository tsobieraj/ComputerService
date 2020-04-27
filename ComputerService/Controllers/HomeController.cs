using ComputerService.Models;
using ComputerService.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerService.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IItemRepository _itemRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        private List<Item> _cart;

        public HomeController(IItemRepository itemRepository, IHostingEnvironment hostingEnvironment)
        {
            if (HttpHelper.HttpContext.Session.GetObjectFromJson<List<Item>>("Cart") == null)
            {
                HttpHelper.HttpContext.Session.SetObjectAsJson("Cart", new List<Item>());
            }

            _itemRepository = itemRepository;
            this.hostingEnvironment = hostingEnvironment;
        }

        [AllowAnonymous]
        public ViewResult Index()
        {
            var model = _itemRepository.GetAllItems();
            return View(model);
        }

        [AllowAnonymous]
        public ViewResult ListCategory(string category)
        {
            var model = _itemRepository.GetItemsByCategory(category);
            return View("index", model);
        }

        [AllowAnonymous]

        public ViewResult Details(int id)
        {
            Item item = _itemRepository.GetItem(id);
            if (item == null)
            {
                Response.StatusCode = 404;
                return View("ItemNotFound", id);
            }

            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Item = item,
                PageTitle = "Item Details"
            };

            return View(homeDetailsViewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _itemRepository.Delete(id);

            return RedirectToAction("index");
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Item item = _itemRepository.GetItem(id);
            ItemEditViewModel itemEditViewModel = new ItemEditViewModel
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                Category = item.Category,
                ExistingPhotoPath = item.PhotoPath
            };

            return View(itemEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ItemEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Item item = _itemRepository.GetItem(model.Id);
                item.Name = model.Name;
                item.Price = model.Price;
                item.Category = model.Category;

                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    item.PhotoPath = ProcessUploadedFile(model);
                }
                Item updatedItem = _itemRepository.Update(item);

                return RedirectToAction("index");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ItemCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);
                Item newItem = new Item
                {
                    Name = model.Name,
                    Price = model.Price,
                    Category = model.Category,
                    PhotoPath = uniqueFileName
                };

                _itemRepository.Add(newItem);
                return RedirectToAction("details", new { id = newItem.Id });
            }
            return View();
        }

        private string ProcessUploadedFile(ItemCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        public IActionResult Cart()
        {
            var cart = HttpHelper.HttpContext.Session.GetObjectFromJson<List<Item>>("Cart");
            return View(cart);
        }

        [AllowAnonymous]
        public IActionResult AddToCart(int id)
        {
            var product = _itemRepository.GetItem(id);
            if (_cart == null)
                _cart = new List<Item>();

            var cart = HttpHelper.HttpContext.Session.GetObjectFromJson<List<Item>>("Cart");
            _cart.Add(product);
            cart.AddRange(_cart);
            HttpHelper.HttpContext.Session.SetObjectAsJson("Cart", cart);
           
            return RedirectToAction("index");
        }

        public IActionResult RemoveFromCart(int id)
        {
            var product = _itemRepository.GetItem(id);


            var cart = HttpHelper.HttpContext.Session.GetObjectFromJson<List<Item>>("Cart");
            foreach (Item item in cart)
            {
                if (item.Id == product.Id)
                {
                    cart.Remove(item);
                    break;
                }
            }
            HttpHelper.HttpContext.Session.SetObjectAsJson("Cart", cart);

            return RedirectToAction("cart");
        }
    }
}
