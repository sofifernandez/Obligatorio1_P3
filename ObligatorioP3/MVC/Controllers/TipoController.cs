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
            IEnumerable<Tipo> tipos = RepositorioTipo.FindAll();
            return View(tipos);
        }


        //-------------------------------------------------------------------------------------
        //BÚSQUEDA-----------------------------------------------------------------------------
        [HttpPost]
        public ActionResult Index(string nombre)
        {

            Tipo tipo = RepositorioTipo.FindTipoByNombre(nombre);
            TempData["MiTipo"] = JsonConvert.SerializeObject(tipo);
            return RedirectToAction("Buscar");
        }

        [HttpGet]
        public ActionResult Buscar()
        {
            TempData["MiTipo"] = JsonConvert.DeserializeObject<Tipo>(TempData["MiTipo"].ToString());
            Tipo miTipo = TempData["MiTipo"] as Tipo;
            if (miTipo != null)
            {
                return View(miTipo);
            }
            else
            {
                ViewBag.Error = "No existe un tipo de cabaña con ese nombre";
                return View();
            }
        }

        //-------------------------------------------------------------------------------------
        //DETALLES-----------------------------------------------------------------------------
        public ActionResult Details(int id)
        {
            Tipo tipo= RepositorioTipo.FindById(id);
            return View(tipo);
        }

        //-------------------------------------------------------------------------------------
        //CREAR-----------------------------------------------------------------------------
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tipo tipo)
        {
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
            Tipo tipo = RepositorioTipo.FindById(id);
            return View(tipo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Tipo tipo)
        {
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
            Tipo tipo=RepositorioTipo.FindById(id);
            return View(tipo);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                RepositorioTipo.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            catch 
            {
                return View();
            }
        }
    }
}
