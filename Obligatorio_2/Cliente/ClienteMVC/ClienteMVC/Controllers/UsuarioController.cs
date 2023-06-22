
using ClienteMVC.DTOs;
using ClienteMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace ClienteMVC.Controllers
{
    public class UsuarioController : Controller
    {
        public IConfiguration Conf { get; set; }

        public UsuarioController(IConfiguration conf)
        {
            Conf = conf;
        }

        // GET: UsuarioController
        public ActionResult Login()
        {
            return View();
        }

       

        [HttpPost]
        public ActionResult Login(UsuarioViewModel usu)
        {
            string url = Conf.GetValue<string>("ApiUsuarios") + "login";
            HttpClient client = new HttpClient();
            var tarea = client.PostAsJsonAsync(url, usu);
            tarea.Wait();

            if (tarea.Result.IsSuccessStatusCode)
            {
                var tarea2 = tarea.Result.Content.ReadAsStringAsync();
                tarea2.Wait();

                LoginDTO login = JsonConvert.DeserializeObject<LoginDTO>(tarea2.Result);
                HttpContext.Session.SetString("token", login.TokenJWT);
                HttpContext.Session.SetString("logeado", "registrado");

                return RedirectToAction("Index", "Cabana");
            }
            else
            {
                if (tarea.Result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    ViewBag.Error = "Las credenciales no son válidas";
                }
                else
                {
                    ViewBag.Error = "Ocurrió un error";
                }

                return View(usu);
            }
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");

        }
        

    }
}
