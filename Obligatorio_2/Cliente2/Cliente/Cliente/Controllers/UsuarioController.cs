
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ClienteMVC.Controllers
{
    public class UsuarioController : Controller
    {
        /*
        IRepositorioUsuario RepoUsuario { get; set; }

        public UsuarioController(IRepositorioUsuario repo)
            {
            RepoUsuario = repo;
            }

        // GET: UsuarioController
        public ActionResult Login()
        {
            return View();
        }

       

        [HttpPost]
        public ActionResult Login(Usuario unUsuario)
        {
            try
            {
                string email = unUsuario.Email;
                string password = unUsuario.Password;
                Usuario usuario = RepoUsuario.Login(email, password);
                if (usuario != null)
                {
                    HttpContext.Session.SetString("email", email);
                    return Redirect("/Home/Index");
                }
                else 
                {
                    ViewBag.Error = "El usuario o la contraseña son incorrectos";
                    return View();
                }

                
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");

        }
        */

    }
}
