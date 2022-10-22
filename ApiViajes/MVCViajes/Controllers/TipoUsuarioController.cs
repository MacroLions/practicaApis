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
    public class TipoUsuarioController : Controller
    {
        string Baseurl = "http://localhost:53230/api/";


        // GET: TipoUsuario
        public ActionResult Index()
        {
            IEnumerable<TipoUsuario> TipoUsuarios = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/");
                //HTTP GET
                var responseTask = client.GetAsync("TipoUsuario");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<TipoUsuario>>();
                    readTask.Wait();

                    TipoUsuarios = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    TipoUsuarios = Enumerable.Empty<TipoUsuario>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(TipoUsuarios);
        }

        //[HttpPost]
        public ActionResult Create(TipoUsuario TipoUsuario)
        {
            return View();

        }

        [HttpPost]
        public ActionResult create(TipoUsuario TipoUsuario)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/TipoUsuario");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<TipoUsuario>("TipoUsuario", TipoUsuario);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(TipoUsuario);
        }

        public ActionResult Edit(int id)
        {
            TipoUsuario TipoUsuario = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/");
                //HTTP GET
                var responseTask = client.GetAsync("TipoUsuario?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<TipoUsuario>();
                    readTask.Wait();

                    TipoUsuario = readTask.Result;
                }
            }

            return View(TipoUsuario);
        }

        [HttpPost]
        public ActionResult Edit(TipoUsuario TipoUsuario)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/TipoUsuario");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<TipoUsuario>("TipoUsuario", TipoUsuario);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(TipoUsuario);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53230/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("TipoUsuario/" + id.ToString());
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