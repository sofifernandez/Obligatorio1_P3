
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClienteMVC.Controllers
{
    public class MantenimientoController : Controller
    {
        /*
        IRepositorioMantenimiento RepositorioMant { get; set; }
        IRepositorioCabana RepositorioCabana { get; set; }
       
        public MantenimientoController(IRepositorioMantenimiento repo, IRepositorioCabana repoCabana)
        {
            RepositorioMant = repo;
            RepositorioCabana = repoCabana;
        }

        //-------------------------------------------------------------------------------------
        //LISTADO-----------------------------------------------------------------------------
        public ActionResult Index(int CabanaId)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            {
                return Redirect("/Usuario/Login");
            }
            IEnumerable<Mantenimiento> mantenimientos= RepositorioMant.FindMantenimientosCabana(CabanaId);
            Cabana cabana=RepositorioCabana.FindById(CabanaId);
            ViewBag.Cabana = cabana;
            if (mantenimientos.Count() == 0) 
            {
                ViewBag.NotFound = "No hay existencias";
            }
            return View(mantenimientos);
        }


        //-------------------------------------------------------------------------------------
        //BÚSQUEDA-----------------------------------------------------------------------------
        [HttpPost]
        public ActionResult MantEntreFechas(DateTime fechaIni, DateTime fechaFin, int CabanaId)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            {
                return Redirect("/Usuario/Login");
            }
            IEnumerable<Mantenimiento> mantenimientos = RepositorioMant.FindMantenimientosFechas(fechaIni, fechaFin, CabanaId);
            Cabana cabana = RepositorioCabana.FindById(CabanaId);
            ViewBag.Cabana = cabana;
            if (mantenimientos.Count() == 0)
            {
                ViewBag.NotFound = "No existen resultados";
            }
            return View(mantenimientos);
        }



        //-------------------------------------------------------------------------------------
        //CREAR-----------------------------------------------------------------------------
        public ActionResult Create(int CabanaId)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            {
                return Redirect("/Usuario/Login");
            }
            Cabana cabana = RepositorioCabana.FindById(CabanaId);
            ViewBag.Cabana=cabana;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Mantenimiento mantenimiento)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            {
                return Redirect("/Usuario/Login");
            }
            try
            {
                Cabana cabana = RepositorioCabana.FindById(mantenimiento.CabanaId);
                mantenimiento.Cabana = cabana;
                RepositorioMant.Add(mantenimiento);
                return RedirectToAction(nameof(Index), new { CabanaId = cabana.Id});
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                Cabana cabana = RepositorioCabana.FindById(mantenimiento.CabanaId);
                ViewBag.Cabana = cabana;
                return View();
            }
        }





        //-----------------------------------------------------------------------------------------------------------------------------------
        //NO IMPLEMENTADOS--------------------------------------------------------------------------------------------------------------------

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

        // GET: MantenimientoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        */
    }
}
