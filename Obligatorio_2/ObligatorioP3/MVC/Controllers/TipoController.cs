using Aplicacion.CU;
using Aplicacion.InterfacesCU;
using Datos.Repositorios;
using Dominio.EntidadesDominio;
using Dominio.InterfacesRepositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MVC.Controllers
{
    public class TipoController : Controller
    {
        IAltaTipo AltaTipo { set; get; } 
        IEditarTipo EditarTipo { set; get; }

        IRepositorioTipo RepositorioTipo { set; get; }

        public TipoController (IAltaTipo altaTipo, IRepositorioTipo repositorioTipo, IEditarTipo editarTipo)
        {
            AltaTipo = altaTipo;
            RepositorioTipo = repositorioTipo;
            EditarTipo = editarTipo;
        }


        //-------------------------------------------------------------------------------------
        //LISTADO-----------------------------------------------------------------------------
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            {
                return Redirect("/Usuario/Login");
            }
            IEnumerable<Tipo> tipos = RepositorioTipo.FindAll();
            if (tipos.Count() == 0) 
            {
                ViewBag.NotFound = "No hay tipos de cabañas ingresados";
            }
            return View(tipos);
        }


        //-------------------------------------------------------------------------------------
        //BÚSQUEDA-----------------------------------------------------------------------------
        [HttpPost]
        public ActionResult Index(string nombre)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            {
                return Redirect("/Usuario/Login");
            }
            Tipo tipo = RepositorioTipo.FindTipoByNombre(nombre);
           
            if (tipo == null)
            {
                ViewBag.Error = "No existe un tipo de cabaña con ese nombre";
                return View("ResultadoBusqueda");
            }
            else 
            {
                return View("ResultadoBusqueda", tipo);
            }
            
        }

       

        //-------------------------------------------------------------------------------------
        //DETALLES-----------------------------------------------------------------------------
        public ActionResult Details(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            {
                return Redirect("/Usuario/Login");
            }
            Tipo tipo= RepositorioTipo.FindById(id);
            return View(tipo);
        }

        //-------------------------------------------------------------------------------------
        //CREAR-----------------------------------------------------------------------------
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            {
                return Redirect("/Usuario/Login");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tipo tipo)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            {
                return Redirect("/Usuario/Login");
            }
            try
            {
                AltaTipo.Alta(tipo);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.ErrorInfo = ex.Message;
                return View();
            }
        }

        //-------------------------------------------------------------------------------------
        //EDITAR-----------------------------------------------------------------------------
        public ActionResult Edit(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            {
                return Redirect("/Usuario/Login");
            }
            Tipo tipo = RepositorioTipo.FindById(id);
            return View(tipo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Tipo tipo)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            {
                return Redirect("/Usuario/Login");
            }
            try
            {

                EditarTipo.Editar(tipo);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorInfo = ex.Message;
                return View();
            }
        }

        //-------------------------------------------------------------------------------------
        //DELETE-----------------------------------------------------------------------------
        public ActionResult Delete(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            {
                return Redirect("/Usuario/Login");
            }
            Tipo tipo=RepositorioTipo.FindById(id);
            return View(tipo);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            {
                return Redirect("/Usuario/Login");
            }
            try
            {
                RepositorioTipo.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            catch  (Exception ex)
            {
                Tipo tipo = RepositorioTipo.FindById(id);
                ViewBag.ErrorInfo = ex.Message;
                return View(tipo);
            }
        }
    }
}
