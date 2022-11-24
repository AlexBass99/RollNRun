﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Roll_n_RunGenNHibernate.EN.Roll_n_Run;
using Roll_n_RunGenNHibernate.CEN.Roll_n_Run;
using Roll_n_RunGenNHibernate.CAD.Roll_n_Run;
using RollNRunWeb.Assemblers;
using RollNRunWeb.Models;

namespace RollNRunWeb.Controllers
{
    public class ProductoController : BasicController
    {
        // GET: Producto
        public ActionResult Index()
        {
            SessionInitialize();
            ProductoCAD productoCAD = new ProductoCAD(session);
            ProductoCEN productoCEN = new ProductoCEN(productoCAD);

            IList<ProductoEN> productosEN = productoCEN.ReadAll(0, -1);
            IEnumerable<ProductoViewModel> productosViewModel = new ProductoAssembler().ConvertListENToModel(productosEN).ToList();
            SessionClose();

            return View(productosViewModel);
        }

        // GET: Producto/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            ProductoCAD productoCAD = new ProductoCAD(session);
            ProductoCEN productoCEN = new ProductoCEN(productoCAD);

            ProductoEN productoEN = productoCEN.ReadOID(id);
            ProductoViewModel productoViewModel = new ProductoAssembler().ConvertENToModelUI(productoEN);

            return View(productoViewModel);
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        public ActionResult Create(ProductoViewModel prod)
        {
            try
            {
                ProductoCEN productoCEN = new ProductoCEN();
                productoCEN.New_(prod.nombre, prod.marca, prod.stock, prod.precio, prod.imagen, prod.descripcion, 0, (Roll_n_RunGenNHibernate.Enumerated.Roll_n_Run.Tipo_productoEnum)prod.tipo_producto, prod.oferta);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int id)
        {
            SessionInitialize();
            ProductoCAD productoCAD = new ProductoCAD(session);
            ProductoCEN productoCEN = new ProductoCEN(productoCAD);

            ProductoEN productoEN = productoCEN.ReadOID(id);
            ProductoViewModel productoViewModel = new ProductoAssembler().ConvertENToModelUI(productoEN);

            SessionClose();

            return View(productoViewModel);
        }

        // POST: Producto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProductoViewModel prod)
        {
            try
            {
                ProductoCEN productoCEN = new ProductoCEN();
                ProductoEN productoEN = productoCEN.ReadOID(id);
                productoCEN.Modify(id, prod.nombre, prod.marca, prod.stock, prod.precio, prod.imagen, prod.descripcion, productoEN.Val_media, prod.tipo_producto, prod.oferta);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int id)
        {
            SessionInitialize();
            ProductoCAD productoCAD = new ProductoCAD(session);
            ProductoCEN productoCEN = new ProductoCEN(productoCAD);

            ProductoEN productoEN = productoCEN.ReadOID(id);
            ProductoViewModel productoViewModel = new ProductoAssembler().ConvertENToModelUI(productoEN);

            SessionClose();

            return View(productoViewModel);
        }

        // POST: Producto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ProductoViewModel prod)
        {
            try
            {
                ProductoCEN productoCEN = new ProductoCEN();
                productoCEN.Destroy(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
