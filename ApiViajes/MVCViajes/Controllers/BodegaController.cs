using ApiViajes.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVCViajes.Controllers
{
    public class BodegaController : Controller
    {
        
        // GET: Bodega
        public ActionResult Index()
        {
            IEnumerable<Bodega> Bodegas = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Bodega");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Bodega>>();
                    readTask.Wait();

                    Bodegas = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    Bodegas = Enumerable.Empty<Bodega>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(Bodegas);
        }

        //[HttpPost]
        public ActionResult Create(Bodega Bodega)
        {
            return View();

        }

        [HttpPost]
        public ActionResult create(Bodega Bodega)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/Bodega");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Bodega>("Bodega", Bodega);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(Bodega);
        }

        public ActionResult Edit(int id)
        {
            Bodega Bodega = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Bodega?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Bodega>();
                    readTask.Wait();

                    Bodega = readTask.Result;
                }
            }

            return View(Bodega);
        }

        [HttpPost]
        public ActionResult Edit(Bodega Bodega)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/Bodega");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Bodega>("Bodega", Bodega);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(Bodega);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Bodega/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }
    }
}