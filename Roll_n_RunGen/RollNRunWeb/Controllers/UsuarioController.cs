using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Roll_n_RunGenNHibernate.CEN.Roll_n_Run;
using Roll_n_RunGenNHibernate.EN.Roll_n_Run;
using Roll_n_RunGenNHibernate.CAD.Roll_n_Run;
using RollNRunWeb.Assemblers;
using RollNRunWeb.Models;

namespace RollNRunWeb.Controllers
{
    public class UsuarioController : BasicController
    {
        // GET: Usuario
        public ActionResult Index()
        {
            SessionInitialize();
            UsuarioCAD usuarioCAD = new UsuarioCAD(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioCAD);

            IList<UsuarioEN> usuariosEN = usuarioCEN.ReadAll(0, -1);
            IEnumerable<UsuarioViewModel> usuariosViewModel = new UsuarioAssembler().ConvertListENToModel(usuariosEN).ToList();
            SessionClose();

            return View(usuariosViewModel);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();

            UsuarioCAD usuarioCAD = new UsuarioCAD(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioCAD);

            UsuarioEN usuarioEN = usuarioCEN.ReadOID(id);
            UsuarioViewModel usuarioViewModel = new UsuarioAssembler().ConvertENToModelUI(usuarioEN);

            SessionClose();

            return View(usuarioViewModel);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(UsuarioViewModel usu)
        {
            try
            {
                UsuarioCEN usuarioCEN = new UsuarioCEN();
                int idUsu = usuarioCEN.New_(usu.nombre, usu.Email, usu.apellidos, usu.alias, usu.Password, usu.rol);
                UsuarioEN usuarioEN = usuarioCEN.ReadOID(idUsu);

                if (usu.telefono != null)           //Si no es un campo vacio se le añade ese nuevo telefono
                {
                    usuarioEN.Telefono = usu.telefono;
                }

                else
                {
                    usuarioEN.Telefono = "Sin registrar";
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            SessionInitialize();
            UsuarioCAD usuarioCAD = new UsuarioCAD(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioCAD);

            UsuarioEN usuarioEN = usuarioCEN.ReadOID(id);
            UsuarioViewModel usuarioViewModel = new UsuarioAssembler().ConvertENToModelUI(usuarioEN);

            SessionClose();

            return View(usuarioViewModel);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UsuarioViewModel usu)
        {
            try
            {
                UsuarioCEN usuarioCEN = new UsuarioCEN();
                usuarioCEN.Modify(id, usu.nombre, usu.Email, usu.apellidos, usu.alias, usu.Password, usu.rol);

                if (usu.telefono != null)     //Si no es un campo vacio se le añade ese nuevo telefono
                {
                    UsuarioEN usuarioEN = usuarioCEN.ReadOID(id);
                    usuarioEN.Telefono = usu.telefono;
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            SessionInitialize();
            UsuarioCAD usuarioCAD = new UsuarioCAD(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioCAD);

            UsuarioEN usuarioEN = usuarioCEN.ReadOID(id);
            UsuarioViewModel usuarioViewModel = new UsuarioAssembler().ConvertENToModelUI(usuarioEN);

            SessionClose();

            return View(usuarioViewModel);
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                UsuarioCEN usuarioCEN = new UsuarioCEN();
                usuarioCEN.Destroy(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
