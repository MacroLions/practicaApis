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
    public class SucursalController : Controller
    {

        // GET: Sucursal
        public ActionResult Index()
        {
            IEnumerable<Sucursal> sucursales = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/");
                //HTTP GET
                var responseTask = client.GetAsync("sucursal");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Sucursal>>();
                    readTask.Wait();

                    sucursales = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    sucursales = Enumerable.Empty<Sucursal>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(sucursales);
        }

        //[HttpPost]
        public ActionResult Create(Sucursal sucursal)
        {
            return View();

        }

        [HttpPost]
        public ActionResult create(Sucursal sucursal)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/Sucursal");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Sucursal>("sucursal", sucursal);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(sucursal);
        }

        public ActionResult Edit(int id)
        {
            Sucursal sucursal = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/");
                //HTTP GET
                var responseTask = client.GetAsync("sucursal?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Sucursal>();
                    readTask.Wait();

                    sucursal = readTask.Result;
                }
            }

            return View(sucursal);
        }

        [HttpPost]
        public ActionResult Edit(Sucursal sucursal)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/Sucursal");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Sucursal>("sucursal", sucursal);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(sucursal);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("sucursal/" + id.ToString());
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