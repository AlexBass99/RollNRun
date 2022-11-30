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

namespace RollNRunWeb.Controllers
{
    public class SubforoController : BasicController
    {
        // GET: Subforo
        public ActionResult Index()
        {
            SessionInitialize();
            SubforoCAD subforoCAD = new SubforoCAD(session);
            SubforoCEN subforoCEN = new SubforoCEN(subforoCAD);

            IList<SubforoEN> subforosEN = subforoCEN.ReadAll(0, -1);
            IEnumerable<SubforoViewModel> subforoViewModel = new SubforoAssembler().ConvertListENToModel(subforosEN).ToList();
            SessionClose();

            return View(subforoViewModel);
        }

        // GET: Subforo/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            SubforoCAD subforoCAD = new SubforoCAD(session);
            SubforoCEN subforoCEN = new SubforoCEN(subforoCAD);

            SubforoEN subforoEN = subforoCEN.ReadOID(id);
            SubforoViewModel subforoViewModel = new SubforoAssembler().ConvertENToModelUI(subforoEN);

            return View(subforoViewModel);
        }

        // GET: Subforo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subforo/Create
        [HttpPost]
        public ActionResult Create(SubforoViewModel sforo)
        {
            try
            {
                // TODO: Add insert logic here
                SubforoCEN subforoCEN = new SubforoCEN();
                if (Session["Usuario"] != null)
                {
                    sforo.Autor = ((UsuarioEN)Session["Usuario"]).Nickname;
                    subforoCEN.New_(((UsuarioEN)Session["Usuario"]).Id, sforo.Titulo, new DateTime(2022, 11, 20), sforo.Descripcion, 0);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Subforo/Edit/5
        public ActionResult Edit(int id)
        {
            SessionInitialize();
            SubforoCAD subforoCAD = new SubforoCAD(session);
            SubforoCEN subforoCEN = new SubforoCEN(subforoCAD);

            SubforoEN subforoEN = subforoCEN.ReadOID(id);
            SubforoViewModel subforoViewModel = new SubforoAssembler().ConvertENToModelUI(subforoEN);

            SessionClose();

            return View(subforoViewModel);
        }

        // POST: Subforo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SubforoViewModel sforo)
        {
            try
            {
                // TODO: Add update logic here
                SubforoCEN subforoCEN = new SubforoCEN();
                SubforoEN subforoEN = subforoCEN.ReadOID(id);
                subforoCEN.Modify(id, sforo.Titulo, sforo.Fecha, sforo.Descripcion, sforo.NumEntradas);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Subforo/Delete/5
        public ActionResult Delete(int id)
        {
            SessionInitialize();
            SubforoCAD subforoCAD = new SubforoCAD(session);
            SubforoCEN subforoCEN = new SubforoCEN(subforoCAD);

            SubforoEN subforoEN = subforoCEN.ReadOID(id);
            SubforoViewModel subforoViewModel = new SubforoAssembler().ConvertENToModelUI(subforoEN);
            SessionClose();

            return View(subforoViewModel);
        }

        // POST: Subforo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, SubforoViewModel sforo)
        {
            try
            {
                // TODO: Add delete logic here
                SubforoCEN subforoCEN = new SubforoCEN();
                subforoCEN.Destroy(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
