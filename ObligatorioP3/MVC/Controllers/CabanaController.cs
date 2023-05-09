﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Aplicacion.CU;
using Aplicacion.InterfacesCU;
using Dominio.InterfacesRepositorios;
using Dominio.EntidadesDominio;
using System.IO;

namespace MVC.Controllers
{
    public class CabanaController : Controller
    {
        IAltaCabana CUAltaCabana { get; set; } 

        IRepositorioCabana RepositorioCabana { get; set; }
        IRepositorioTipo RepositorioTipo { get; set; }

        public CabanaController(IAltaCabana cuAltaCabana, IRepositorioCabana repositorioCabana, IRepositorioTipo repositorioTipo)
        {
            CUAltaCabana = cuAltaCabana;
            RepositorioCabana = repositorioCabana;
            RepositorioTipo = repositorioTipo;
        }

        //-------------------------------------------------------------------------------------
        //LISTADO-----------------------------------------------------------------------------
        public ActionResult Index()
        {
            IEnumerable<Cabana> cabanas = RepositorioCabana.FindAll();
            ViewBag.Tipos= RepositorioTipo.FindAll();
            return View(cabanas);
        }


        //-------------------------------------------------------------------------------------
        //BÚSQUEDAS-----------------------------------------------------------------------------
        [HttpPost]
        public ActionResult BuscarPorNombre(string nombre) 
        { 
            IEnumerable<Cabana> cabanas=RepositorioCabana.FindCabanaNombre(nombre);
            if (cabanas.Count()>0) 
            {
                return View("ResultadoBusqueda",cabanas);
            } else 
            {
                ViewBag.NotFound = "No existen resultados";
                return View("ResultadoBusqueda", cabanas); 
            }
        }

        [HttpGet]
        public ActionResult BuscarHabilitadas()
        {
            IEnumerable<Cabana> cabanas = RepositorioCabana.FindCabanasHabilitadas();
            if (cabanas.Count() > 0)
            {
                return View("ResultadoBusqueda", cabanas);
            }
            else
            {
                ViewBag.NotFound = "No existen resultados";
                return View("ResultadoBusqueda", cabanas);
            }
        }

        [HttpPost]
        public ActionResult BuscarPorMaxHuespedes(int maxHuespedes)
        {
            IEnumerable<Cabana> cabanas = RepositorioCabana.FindCabanaMax(maxHuespedes);
            if (cabanas.Count() > 0)
            {
                return View("ResultadoBusqueda", cabanas);
            }
            else
            {
                ViewBag.NotFound = "No existen resultados";
                return View("ResultadoBusqueda", cabanas);
            }
        }

        [HttpPost]
        public ActionResult BuscarPorTipo(int idTipo)
        {
            IEnumerable<Cabana> cabanas = RepositorioCabana.FindCabanaTipo(idTipo);
            if (cabanas.Count() > 0)
            {
                return View("ResultadoBusqueda", cabanas);
            }
            else
            {
                ViewBag.NotFound = "No existen resultados";
                return View("ResultadoBusqueda", cabanas);
            }
        }


        // GET: CabanaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //-------------------------------------------------------------------------------------------------------
        //CREATE-------------------------------------------------------------------------------------------------
        public ActionResult Create()
        {
            IEnumerable<Tipo> tipos= RepositorioTipo.FindAll();
            ViewBag.Tipos = tipos;
            return View();
        }

        // POST: CabanaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cabana cabana, int idTipo)
        {
            try
            {
                Tipo tipo = RepositorioTipo.FindById(idTipo);
                cabana.Tipo = tipo;
                CUAltaCabana.Alta(cabana);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                IEnumerable<Tipo> tipos = RepositorioTipo.FindAll();
                ViewBag.Tipos = tipos;
                ViewBag.ErrorInfo=ex.Message;
                if (ex.InnerException != null && ex.InnerException.Message.Contains("Cannot insert duplicate key row in object")) 
                {
                    ViewBag.ErrorInfo = " ";
                    ViewBag.Prueba = "El nombre de cabaña ya existe";
                }
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
