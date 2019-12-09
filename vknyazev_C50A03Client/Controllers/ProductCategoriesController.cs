using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vknyazev_C50A03Client.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using vknyazev_C50A03Services.Models;
using System.Net.Http.Formatting;
using System.IO;

namespace vknyazev_C50A03Client.Controllers
{
    public class ProductCategoriesController : Controller
    {
        private readonly HttpClient _client;
        private const string serviceRoot = "http://localhost:3000/";

        public ProductCategoriesController(HttpClient client) {
            _client = client;
        }

        public async Task<IActionResult> Index()
        {

            string uri = serviceRoot + "ProductCategories";
            return View(await ReadObject<List<ProductCategory>>(uri));
        }

        // GET: ProductCategories/Details/5
        public async Task<IActionResult> Details(int id)
        {

            string uri = serviceRoot + "ProductCategories/" + id;
            try
            {
                return View(await ReadObject<ProductCategory>(uri));
            }
            catch (HttpRequestException)
            {
                return NotFound();
            }
            }

        // GET: ProductCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        //// POST: ProductCategories/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,ProdCat")] ProductCategory productCategory)
        {
            HttpResponseMessage response = await _client.PostAsync(serviceRoot + "ProductCategories", productCategory, new JsonMediaTypeFormatter());

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");
            else
            {
                return BadRequest();
            }
        }

        // GET: ProductCategories/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            string uri = serviceRoot + "ProductCategories/" + id;

            var serializer = new DataContractJsonSerializer(typeof(ProductCategory));
            try
            {
                return View(await ReadObject<ProductCategory>(uri));
            }
            catch (HttpRequestException)
            {
                return NotFound();
            }
        

    }

        // POST: ProductCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,ProdCat")] ProductCategory productCategory)
        {
            HttpResponseMessage response = await _client.PutAsync(serviceRoot + "ProductCategories/" + id.ToString(), productCategory, new JsonMediaTypeFormatter());

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");
            else
            {
                return NotFound();
            }
        }

        // GET: ProductCategories/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            string uri = serviceRoot + "ProductCategories/" + id;

            var serializer = new DataContractJsonSerializer(typeof(ProductCategory));
            try
            {
                return View(await ReadObject<ProductCategory>(uri));
            }
            catch (HttpRequestException)
            {
                return NotFound();
            }
        }
        private async Task<T> ReadObject<T>(string uri) where T: class => ReadObject<T>(await _client.GetStreamAsync(uri));

        private T ReadObject<T>(Stream stream) where T: class {
            var serializer = new DataContractJsonSerializer(typeof(T));
            var result = serializer.ReadObject(stream) as T;

            return result;
        }

        //// POST: ProductCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            HttpResponseMessage response = await _client.DeleteAsync(serviceRoot + "ProductCategories/" + id.ToString());
            
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");
            else
            {
                return NotFound();
            }
        }
    }
}
