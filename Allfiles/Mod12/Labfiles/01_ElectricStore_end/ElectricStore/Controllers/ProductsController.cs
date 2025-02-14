﻿using ElectricStore.Data;
using ElectricStore.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace ElectricStore.Controllers;

public class ProductsController : Controller
{
    private StoreContext _context;
    private IWebHostEnvironment _environment;
    private IMemoryCache _memoryCache;
    private const string PRODUCT_KEY = "Products";

    public ProductsController(StoreContext context, IWebHostEnvironment environment, IMemoryCache memoryCache)
    {
        _context = context;
        _environment = environment;
        _memoryCache = memoryCache;
    }

    public IActionResult Index()
    {
        List<Product> products;
        if (!_memoryCache.TryGetValue(PRODUCT_KEY, out products))
        {
            products = _context.Products.ToList();
            products.Select(c => { c.LoadedFromDatabase = DateTime.Now; return c; }).ToList();
            MemoryCacheEntryOptions cacheOptions = new MemoryCacheEntryOptions();
            cacheOptions.SetPriority(CacheItemPriority.High);
            _memoryCache.Set(PRODUCT_KEY, products, cacheOptions);
        }
        return View(products);
    }

    public IActionResult GetByCategory(int Id)
    {
        var products = _context.Products.Where(c => c.CategoryId == Id);
        var category = _context.menuCategories.FirstOrDefault(c => c.Id == Id);
        ViewBag.categoryTitle = category?.Name;
        return View(products);
    }

    [HttpGet]
    public IActionResult AddToShoppingList()
    {
        if (HttpContext.Session.GetString("CustomerFirstName") != null)
        {
            Customer sessionCustomer = new Customer()
            {
                FirstName = HttpContext.Session.GetString("CustomerFirstName") ?? "",
                LastName = HttpContext.Session.GetString("CustomerLastName") ?? "" ,
                Email = HttpContext.Session.GetString("CustomerEmail") ?? "",
                Address = HttpContext.Session.GetString("CustomerAddress") ?? "",
                PhoneNumber = HttpContext.Session.GetInt32("CustomerPhoneNumber") ?? 0,
            };
            PopulateProductsList();
            return View(sessionCustomer);
        }
        PopulateProductsList();
        return View();
    }

    [HttpPost, ActionName("AddToShoppingList")]
    public IActionResult AddToShoppingListPost(Customer customer)
    {
        if (ModelState.IsValid)
        {
            HttpContext.Session.SetString("CustomerFirstName", customer.FirstName);
            HttpContext.Session.SetString("CustomerLastName", customer.LastName);
            HttpContext.Session.SetString("CustomerEmail", customer.Email);
            HttpContext.Session.SetString("CustomerAddress", customer.Address);
            HttpContext.Session.SetInt32("CustomerPhoneNumber", customer.PhoneNumber);
            if (HttpContext.Session.GetString("CustomerProducts") != null)
            {
                List<int> productsListId =  JsonSerializer.Deserialize<List<int>>(HttpContext.Session.GetString("CustomerProducts")?? "")?? new List<int>();
                customer.SelectedProductsList.AddRange(productsListId);
            }
            var serialisedDate = JsonSerializer.Serialize(customer.SelectedProductsList);
            HttpContext.Session.SetString("CustomerProducts", serialisedDate);
            return RedirectToAction(nameof(Index));
        }
        PopulateProductsList(customer.SelectedProductsList);
        return View(customer);
    }

    private void PopulateProductsList(List<int>? selectedProducts = null)
    {
        var products = from p in _context.Products
                       orderby p.ProductName
                       select p;

        ViewBag.ProductsList = new MultiSelectList(products.AsNoTracking(), "Id", "ProductName", selectedProducts);
    }

    public IActionResult GetImage(int productId)
    {
        Product? requestedPhoto = _context.Products.SingleOrDefault(i => i.Id == productId);
        if (requestedPhoto != null)
        {
            string webRootpath = _environment.WebRootPath;
            string folderPath = "\\images\\";
            string fullPath = webRootpath + folderPath + requestedPhoto.PhotoFileName;

            FileStream fileOnDisk = new FileStream(fullPath, FileMode.Open);
            byte[] fileBytes;
            using (BinaryReader br = new BinaryReader(fileOnDisk))
            {
                fileBytes = br.ReadBytes((int)fileOnDisk.Length);
            }
            return File(fileBytes, requestedPhoto.ImageMimeType);
        }
        else
        {
            return NotFound();
        }
    }
}
