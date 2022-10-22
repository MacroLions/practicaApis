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
    public class InformePaqueteController : Controller
    {

        // GET: InformePaquete
        public ActionResult Index()
        {
            IEnumerable<InformePaquete> InformePaquetes = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/");
                //HTTP GET
                var responseTask = client.GetAsync("informePaquete");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<InformePaquete>>();
                    readTask.Wait();

                    InformePaquetes = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    InformePaquetes = Enumerable.Empty<InformePaquete>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(InformePaquetes);
        }

        //[HttpPost]
        public ActionResult Create(InformePaquete InformePaquete)
        {
            return View();

        }

        [HttpPost]
        public ActionResult create(InformePaquete InformePaquete)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/InformePaquete");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<InformePaquete>("InformePaquete", InformePaquete);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(InformePaquete);
        }

        public ActionResult Edit(int id)
        {
            InformePaquete InformePaquete = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/");
                //HTTP GET
                var responseTask = client.GetAsync("InformePaquete?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<InformePaquete>();
                    readTask.Wait();

                    InformePaquete = readTask.Result;
                }
            }

            return View(InformePaquete);
        }

        [HttpPost]
        public ActionResult Edit(InformePaquete InformePaquete)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/InformePaquete");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<InformePaquete>("informePaquete", InformePaquete);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(InformePaquete);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("informePaquete/" + id.ToString());
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