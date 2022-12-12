using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Roll_n_RunGenNHibernate.CAD.Roll_n_Run;
using Roll_n_RunGenNHibernate.CEN.Roll_n_Run;
using Roll_n_RunGenNHibernate.EN.Roll_n_Run;
using RollNRunWeb.Assemblers;
using RollNRunWeb.Models;

namespace RollNRunWeb.Controllers
{
    public class LineaPedidoController : BasicController
    {
        // GET: LineaPedido
        public ActionResult Index()
        {
            SessionInitialize();
            LineaPedidoCAD linpeCAD = new LineaPedidoCAD(session);
            LineaPedidoCEN linpeCEN = new LineaPedidoCEN(linpeCAD);

            IList<LineaPedidoEN> linpeEN = linpeCEN.ReadAll(0, -1);
            IEnumerable<LineaPedidoViewModel> linpeViewModel = new LineaPedidoAssembler().ConvertListENToModel(linpeEN).ToList();
            SessionClose();

            return View(linpeViewModel);
        }

        // GET: LineaPedido/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            LineaPedidoCAD linpeCAD = new LineaPedidoCAD(session);
            LineaPedidoCEN linpeCEN = new LineaPedidoCEN(linpeCAD);

            LineaPedidoEN linpeEN = linpeCEN.ReadOID(id);
            LineaPedidoViewModel linpeViewModel = new LineaPedidoAssembler().ConvertENToModelUI(linpeEN);
            SessionClose();

            return View(linpeViewModel);
        }

        // GET: LineaPedido/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LineaPedido/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LineaPedido/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LineaPedido/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LineaPedido/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LineaPedido/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
