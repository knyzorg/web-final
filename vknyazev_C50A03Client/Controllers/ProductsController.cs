using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using vknyazev_C50A03Services.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Net.Http.Formatting;
using System.IO;

namespace vknyazev_C50A03Client.Views.Home
{
    public class ProductsController : Controller
    {
        private readonly HttpClient _client;
        private const string serviceRoot = "http://localhost:3000/";

        public ProductsController(HttpClient client)
        {
            _client = client;
        }

        public async Task<IActionResult> Index(int? orderBy, int? category)
        {
            List<Product> products = await ReadObject<List<Product>>(serviceRoot + "Products?orderBy=" + orderBy + "&category=" + category);
            List<ProductCategory> categories = await ReadObject<List<ProductCategory>>(serviceRoot + "ProductCategories");

            List<SelectListItem> categoryListItems = new SelectList(categories, "CategoryId", "ProdCat", category).Prepend(new SelectListItem { Text = "All" }).ToList();

            List<SelectListItem> orderByList = new List<SelectListItem> {
                new SelectListItem() {Text="Description", Value="0"},
                new SelectListItem() {Text="Category", Value="1"},
                new SelectListItem() {Text="Manufacturer", Value="2"},
                new SelectListItem() {Text="Stock", Value="3"},
                new SelectListItem() {Text="Buy Price", Value="4"},
                new SelectListItem() {Text="Sell Price", Value="5"},
            };
            
            orderByList[orderBy ?? 0].Selected = true;



            ViewData["orderBy"] = orderByList;
            ViewData["ProdCatId"] = categoryListItems;

            return View(products);
        }

        //// GET: Products/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                return View(await ReadObject<Product>(serviceRoot + "Products/" + id));
            }
            catch (HttpRequestException)
            {
                return NotFound();
            }
        }

        // GET: Products/Create
        public async Task<IActionResult> Create()
        {
            List<ProductCategory> categories = await ReadObject<List<ProductCategory>>(serviceRoot + "ProductCategories");
            ViewData["ProdCatId"] = new SelectList(categories, "CategoryId", "ProdCat");

            return View();
        }

        //// POST: Products/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProdCatId,Description,Manufacturer,Stock,BuyPrice,SellPrice")] Product product)
        {
            HttpResponseMessage response = await _client.PostAsync(serviceRoot + "Products", product, new JsonMediaTypeFormatter());

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");
            else
            {
                return NotFound();
            }
        }

        //// GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                ViewData["ProdCatId"] = new SelectList(await ReadObject<List<ProductCategory>>(serviceRoot + "ProductCategories"), "CategoryId", "ProdCat");
                return View(await ReadObject<Product>(serviceRoot + "Products/" + id));
            }
            catch (HttpRequestException)
            {
                return NotFound();
            }
        }

        //// POST: Products/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProdCatId,Description,Manufacturer,Stock,BuyPrice,SellPrice")] Product product)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await _client.PutAsync(serviceRoot + "Products/" + id.ToString(), product, new JsonMediaTypeFormatter());

            return RedirectToAction("Index");

        }

        //// GET: Products/Edit/5
        public async Task<IActionResult> Stock(int? id)
        {

            try
            {
                Product ProdObj = await ReadObject<Product>(serviceRoot + "Products/" + id);
                List<ProductCategory> ProdCatList = await ReadObject<List<ProductCategory>>(serviceRoot + "ProductCategories");

                ViewData["ProdCatId"] = new SelectList(ProdCatList, "CategoryId", "ProdCat");
                return View(ProdObj);
            }
            catch (HttpRequestException)
            {
                return NotFound();
            }
        }

        //// POST: Products/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Stock(int id, [Bind("ProductId,ProdCatId,Description,Manufacturer,Stock,BuyPrice,SellPrice")] Product product)
        {
            HttpClient client = new HttpClient();
            await _client.PutAsync(serviceRoot + "Products/" + id.ToString(), product, new JsonMediaTypeFormatter());

            return RedirectToAction("Index");

        }

        //// GET: Products/Edit/5
        public async Task<IActionResult> Prices(int id)
        {
            try
            {
                ViewData["ProdCatId"] = new SelectList(await ReadObject<List<ProductCategory>>(serviceRoot + "ProductCategories"), "CategoryId", "ProdCat");
                return View(await ReadObject<Product>(serviceRoot + "Products/" + id));
            }
            catch (HttpRequestException)
            {
                return NotFound();
            }
        }

        //// POST: Products/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Prices(int id, [Bind("ProductId,ProdCatId,Description,Manufacturer,Stock,BuyPrice,SellPrice")] Product product)
        {
            HttpResponseMessage response = await _client.PutAsync(serviceRoot + "Products/" + id, product, new JsonMediaTypeFormatter());

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");
            else
                return NotFound();

        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return View(await ReadObject<Product>(serviceRoot + "Products/" + id));
            }
            catch (HttpRequestException)
            {
                return NotFound();
            }
        }

        //// POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            HttpResponseMessage response = await _client.DeleteAsync(serviceRoot + "Products/" + id);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");
            else
            {
                return NotFound();
            }
        }


        private async Task<T> ReadObject<T>(string uri) where T : class => ReadObject<T>(await _client.GetStreamAsync(uri));

        private T ReadObject<T>(Stream stream) where T : class
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            var result = serializer.ReadObject(stream) as T;

            return result;
        }
    }
}
