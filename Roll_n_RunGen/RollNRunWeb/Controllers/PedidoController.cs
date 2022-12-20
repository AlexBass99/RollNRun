using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Roll_n_RunGenNHibernate.EN.Roll_n_Run;
using Roll_n_RunGenNHibernate.CEN.Roll_n_Run;
using Roll_n_RunGenNHibernate.CAD.Roll_n_Run;
using RollNRunWeb.Models;
using RollNRunWeb.Assemblers;
using System.IO;
using Roll_n_RunGenNHibernate.CP.Roll_n_Run;

namespace RollNRunWeb.Controllers
{
    public class PedidoController : BasicController
    {
        // GET: Pedido
        public ActionResult Index()
        {
            SessionInitialize();

            PedidoCAD pedCad = new PedidoCAD(session);
            PedidoCEN pedCEN = new PedidoCEN(pedCad);

            IList<PedidoEN> listEN = pedCEN.ReadAll(0, -1);
            IEnumerable<PedidoViewModel> listViewModel = new PedidoAssembler().ConvertListENToModel(listEN).ToList();

            SessionClose();

            return View(listViewModel);
        }

        // GET: Pedido/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            PedidoCAD pedCAD = new PedidoCAD(session);
            PedidoCEN pedCEN = new PedidoCEN(pedCAD);

            PedidoEN pedEN = pedCEN.ReadOID(id);
            PedidoViewModel pedidoViewModel = new PedidoAssembler().ConvertENToModelUI(pedEN);
            SessionClose();

            return View(pedidoViewModel);
        }

        // GET: Pedido/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pedido/Create
        [HttpPost]
        public ActionResult Create(PedidoViewModel ped)
        //Al crear, pues no crea el total y la cantidad, entiendo el porqué, ya que abajo no lo pongo, pero como no
        //me dejaba ponerlo, prefiero preguntar primero antes de tocar algo y liarla
        {
            try
            {
                // TODO: Add insert logic here
                PedidoCEN pedCEN = new PedidoCEN();
                if (Session["Usuario"] != null)
                {
                    ped.usuario = ((UsuarioEN)Session["Usuario"]).Id;
                    pedCEN.New_(DateTime.Now, ped.Dirección, ((UsuarioEN)Session["Usuario"]).Id);
                }
                // pedCEN.New_(ped.Fecha, ped.Dirección, ped.usuario);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pedido/Edit/5
        public ActionResult Edit(int id)
        {
            SessionInitialize();
            PedidoCAD pedidoCAD = new PedidoCAD(session);
            PedidoCEN pedidoCEN = new PedidoCEN(pedidoCAD);

            PedidoEN pedidoEN = pedidoCEN.ReadOID(id);
            PedidoViewModel pedidoViewModel = new PedidoAssembler().ConvertENToModelUI(pedidoEN);

            SessionClose();

            return View(pedidoViewModel);
        }

        // POST: Pedido/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PedidoViewModel ped)
        //Hay un problema al editar el Total, solo permite editar números enteros, si pones una "," no te deja y si pones un "."
        //lo asume como 0
        {
            try
            {
                PedidoCEN pedidoCEN = new PedidoCEN();
                PedidoEN pedidoEN = pedidoCEN.ReadOID(id);
                pedidoCEN.Modify(id, DateTime.Now, ped.Dirección, pedidoEN.Total, pedidoEN.Cantidad, ped.MetodoPago, pedidoEN.Estado);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pedido/Delete/5
        public ActionResult Delete(int id)
        {
            SessionInitialize();
            PedidoCAD pedCAD = new PedidoCAD(session);
            PedidoCEN pedCEN = new PedidoCEN(pedCAD);

            PedidoEN pedEN = pedCEN.ReadOID(id);
            PedidoViewModel pedViewModel = new PedidoAssembler().ConvertENToModelUI(pedEN);

            SessionClose();

            return View(pedViewModel);
        }

        // POST: Pedido/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PedidoViewModel ped)
        {
            try
            {
                PedidoCEN pedCEN = new PedidoCEN();
                LineaPedidoCEN lpedCEN = new LineaPedidoCEN();
                LineaPedidoCP lpedCP = new LineaPedidoCP();
                IList<LineaPedidoEN> lineas = lpedCEN.GetLineasPedido(id);

                foreach (LineaPedidoEN pe in lineas)
                {
                    lpedCP.Destroy(pe.Id);
                }

                pedCEN.Destroy(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Devolver()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Devolver(int id, DevolucionViewModel dev)
        {
            try
            {
                // TODO: Add insert logic here
                DevolucionCEN devolucionCEN = new DevolucionCEN();
                PedidoCP pedidoCP = new PedidoCP();
                if (Session["Usuario"] != null)
                {
                    dev.usuario = ((UsuarioEN)Session["Usuario"]).Id;
                    pedidoCP.DevolverPedido(id, dev.Descripcion, dev.Motivo, dev.usuario);
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

    }
}
