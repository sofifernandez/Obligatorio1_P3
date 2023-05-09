using Aplicacion.InterfacesCU;
using Dominio.EntidadesDominio;
using Dominio.InterfacesRepositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class MantenimientoController : Controller
    {

        IRepositorioMantenimiento RepositorioMant { get; set; }

        IRepositorioCabana RepositorioCabana { get; set; }
       

        public MantenimientoController(IRepositorioMantenimiento repo, IRepositorioCabana repoCabana)
        {
            RepositorioMant = repo;
            RepositorioCabana = repoCabana;
        }


        // GET: MantenimientoController
        public ActionResult Index(int idCabana)
        {
            IEnumerable<Mantenimiento> mantenimientos= RepositorioMant.FindMantenimientosCabana(idCabana);
            Cabana cabana=RepositorioCabana.FindById(idCabana);
            ViewBag.Cabana = cabana;
            return View(mantenimientos);
        }



        [HttpPost]
        public ActionResult MantEntreFechas(DateOnly fechaIni, DateOnly fechaFin, int idCabana)
        {
            IEnumerable<Mantenimiento> mantenimientos = RepositorioMant.FindMantenimientosFechas(fechaIni, fechaFin, idCabana);
            if (mantenimientos.Count() == 0)
            {
                ViewBag.NotFound = "No existen resultados";
            }
            return View(mantenimientos);
        }



        // GET: MantenimientoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MantenimientoController/Create
        public ActionResult Create(int idCabana)
        {
            Cabana cabana = RepositorioCabana.FindById(idCabana);
            ViewBag.Cabana=cabana;
            return View();
        }

        // POST: MantenimientoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Mantenimiento mantenimiento)
        {
            try
            {
                RepositorioMant.Add(mantenimiento);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                Cabana cabana = RepositorioCabana.FindById(mantenimiento.CabanaId);
                ViewBag.Cabana = cabana;
                return View();
            }
        }

        // GET: MantenimientoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MantenimientoController/Edit/5
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

        // GET: MantenimientoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MantenimientoController/Delete/5
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
