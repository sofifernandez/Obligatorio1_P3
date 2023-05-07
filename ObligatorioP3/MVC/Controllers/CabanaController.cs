using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Aplicacion.CU;
using Aplicacion.InterfacesCU;
using Dominio.InterfacesRepositorios;
using Dominio.EntidadesDominio;

namespace MVC.Controllers
{
    public class CabanaController : Controller
    {
        IAltaCabana CUAltaCabana { get; set; } 

        IRepositorioCabana RepositorioCabana { get; set; }

        public CabanaController(IAltaCabana cuAltaCabana, IRepositorioCabana repositorioCabana)
        {
            CUAltaCabana = cuAltaCabana;
            RepositorioCabana = repositorioCabana;
        }

        // GET: CabanaController
        public ActionResult Index()
        {
            IEnumerable<Cabana> cabanas = RepositorioCabana.FindAll();
            return View(cabanas);
        }

        // GET: CabanaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CabanaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CabanaController/Create
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

        // GET: CabanaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CabanaController/Edit/5
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

        // GET: CabanaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CabanaController/Delete/5
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
