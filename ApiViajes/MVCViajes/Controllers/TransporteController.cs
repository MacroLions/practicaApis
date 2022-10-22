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
    public class TransporteController : Controller
    {
        string Baseurl = "http://localhost:53230/api/";


        // GET: Transporte
        public ActionResult Index()
        {
            IEnumerable<Transporte> Transportes = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Transporte");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Transporte>>();
                    readTask.Wait();

                    Transportes = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    Transportes = Enumerable.Empty<Transporte>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(Transportes);
        }

        //[HttpPost]
        public ActionResult Create(Transporte Transporte)
        {
            return View();

        }

        [HttpPost]
        public ActionResult create(Transporte Transporte)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/Transporte");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Transporte>("Transporte", Transporte);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(Transporte);
        }

        public ActionResult Edit(int id)
        {
            Transporte Transporte = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Transporte?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Transporte>();
                    readTask.Wait();

                    Transporte = readTask.Result;
                }
            }

            return View(Transporte);
        }

        [HttpPost]
        public ActionResult Edit(Transporte Transporte)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/Transporte");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Transporte>("Transporte", Transporte);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(Transporte);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Transporte/" + id.ToString());
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