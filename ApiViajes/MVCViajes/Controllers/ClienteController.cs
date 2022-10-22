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
    public class ClienteController : Controller
    {
        string Baseurl = "http://localhost:53230/api/";

        // GET: Cliente
        public ActionResult Index()
        {
            IEnumerable<Cliente> Clientes = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Cliente");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Cliente>>();
                    readTask.Wait();

                    Clientes = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    Clientes = Enumerable.Empty<Cliente>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(Clientes);
        }

        //[HttpPost]
        public ActionResult Create(Cliente Cliente)
        {
            return View();

        }

        [HttpPost]
        public ActionResult create(Cliente Cliente)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/Cliente");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Cliente>("Cliente", Cliente);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(Cliente);
        }

        public ActionResult Edit(int id)
        {
            Cliente Cliente = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Cliente?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Cliente>();
                    readTask.Wait();

                    Cliente = readTask.Result;
                }
            }

            return View(Cliente);
        }

        [HttpPost]
        public ActionResult Edit(Cliente Cliente)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/Cliente");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Cliente>("Cliente", Cliente);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(Cliente);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Cliente/" + id.ToString());
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