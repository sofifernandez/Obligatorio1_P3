using Aplicacion.InterfacesCU;
using Dominio.InterfacesRepositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class TipoController : Controller
    {
        IAltaTipo AltaTipo { set; get; } 

        IRepositorioTipo RepositorioTipo { set; get; }

        public TipoController (IAltaTipo altaTipo, IRepositorioTipo repositorioTipo)
        {
            AltaTipo = altaTipo;
            RepositorioTipo = repositorioTipo;
        }


        // GET: TipoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TipoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
