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
    public class StatusPaqueteController : Controller
    {

        // GET: StatusPaquete
        public ActionResult Index()
        {
            IEnumerable<StatusPaquete> StatusPaquetees = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/");
                //HTTP GET
                var responseTask = client.GetAsync("StatusPaquete");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<StatusPaquete>>();
                    readTask.Wait();

                    StatusPaquetees = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    StatusPaquetees = Enumerable.Empty<StatusPaquete>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(StatusPaquetees);
        }

        //[HttpPost]
        public ActionResult Create(StatusPaquete StatusPaquete)
        {
            return View();

        }

        [HttpPost]
        public ActionResult create(StatusPaquete StatusPaquete)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/StatusPaquete");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<StatusPaquete>("StatusPaquete", StatusPaquete);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(StatusPaquete);
        }

        public ActionResult Edit(int id)
        {
            StatusPaquete StatusPaquete = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/");
                //HTTP GET
                var responseTask = client.GetAsync("StatusPaquete?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<StatusPaquete>();
                    readTask.Wait();

                    StatusPaquete = readTask.Result;
                }
            }

            return View(StatusPaquete);
        }

        [HttpPost]
        public ActionResult Edit(StatusPaquete StatusPaquete)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/StatusPaquete");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<StatusPaquete>("StatusPaquete", StatusPaquete);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(StatusPaquete);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("StatusPaquete/" + id.ToString());
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