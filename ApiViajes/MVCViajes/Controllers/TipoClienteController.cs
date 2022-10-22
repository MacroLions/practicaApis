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
    public class TipoClienteController : Controller
    {
        string Baseurl = "http://localhost:53230/api/";


        // GET: TipoCliente
        public ActionResult Index()
        {
            IEnumerable<TipoCliente> TipoClientes = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/");
                //HTTP GET
                var responseTask = client.GetAsync("TipoCliente");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<TipoCliente>>();
                    readTask.Wait();

                    TipoClientes = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    TipoClientes = Enumerable.Empty<TipoCliente>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(TipoClientes);
        }

        //[HttpPost]
        public ActionResult Create(TipoCliente TipoCliente)
        {
            return View();

        }

        [HttpPost]
        public ActionResult create(TipoCliente TipoCliente)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/TipoCliente");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<TipoCliente>("TipoCliente", TipoCliente);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(TipoCliente);
        }

        public ActionResult Edit(int id)
        {
            TipoCliente TipoCliente = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/");
                //HTTP GET
                var responseTask = client.GetAsync("TipoCliente?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<TipoCliente>();
                    readTask.Wait();

                    TipoCliente = readTask.Result;
                }
            }

            return View(TipoCliente);
        }

        [HttpPost]
        public ActionResult Edit(TipoCliente TipoCliente)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/TipoCliente");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<TipoCliente>("TipoCliente", TipoCliente);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(TipoCliente);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("TipoCliente/" + id.ToString());
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