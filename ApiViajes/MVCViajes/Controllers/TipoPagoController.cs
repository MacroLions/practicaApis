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
    public class TipoPagoController : Controller
    {
        string Baseurl = "http://localhost:53230/api/";


        // GET: TipoPago
        public ActionResult Index()
        {
            IEnumerable<TipoPago> TipoPagos = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/");
                //HTTP GET
                var responseTask = client.GetAsync("TipoPago");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<TipoPago>>();
                    readTask.Wait();

                    TipoPagos = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    TipoPagos = Enumerable.Empty<TipoPago>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(TipoPagos);
        }

        //[HttpPost]
        public ActionResult Create(TipoPago TipoPago)
        {
            return View();

        }

        [HttpPost]
        public ActionResult create(TipoPago TipoPago)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/TipoPago");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<TipoPago>("TipoPago", TipoPago);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(TipoPago);
        }

        public ActionResult Edit(int id)
        {
            TipoPago TipoPago = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/");
                //HTTP GET
                var responseTask = client.GetAsync("TipoPago?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<TipoPago>();
                    readTask.Wait();

                    TipoPago = readTask.Result;
                }
            }

            return View(TipoPago);
        }

        [HttpPost]
        public ActionResult Edit(TipoPago TipoPago)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/TipoPago");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<TipoPago>("TipoPago", TipoPago);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(TipoPago);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("TipoPago/" + id.ToString());
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