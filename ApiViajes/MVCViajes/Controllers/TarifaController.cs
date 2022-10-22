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
    public class TarifaController : Controller
    {
        string Baseurl = "http://localhost:53230/api/";


        // GET: Tarifa
        public ActionResult Index()
        {
            IEnumerable<Tarifa> Tarifas = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Tarifa");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Tarifa>>();
                    readTask.Wait();

                    Tarifas = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    Tarifas = Enumerable.Empty<Tarifa>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(Tarifas);
        }

        //[HttpPost]
        public ActionResult Create(Tarifa Tarifa)
        {
            return View();

        }

        [HttpPost]
        public ActionResult create(Tarifa Tarifa)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/Tarifa");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Tarifa>("Tarifa", Tarifa);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(Tarifa);
        }

        public ActionResult Edit(int id)
        {
            Tarifa Tarifa = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Tarifa?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Tarifa>();
                    readTask.Wait();

                    Tarifa = readTask.Result;
                }
            }

            return View(Tarifa);
        }

        [HttpPost]
        public ActionResult Edit(Tarifa Tarifa)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/Tarifa");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Tarifa>("Tarifa", Tarifa);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(Tarifa);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Tarifa/" + id.ToString());
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