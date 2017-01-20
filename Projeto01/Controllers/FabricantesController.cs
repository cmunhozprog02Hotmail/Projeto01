using Projeto01.Contexts;
using Projeto01.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Projeto01.Controllers
{
    public class FabricantesController : Controller
    {
        private EFContext context = new EFContext();
        // GET: Fabricantes
        public ActionResult Index()
        {
            return View(context.Fabricantes.OrderBy(c => c.Nome));
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fabricante fabricante)
        {
            context.Fabricantes.Add(fabricante);
            context.SaveChanges();
            return RedirectToAction("index");
        }
        // GET: EDIT
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = context.Fabricantes.Find(id);
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }
        // POST FABRICANTE EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fabricante fabricante)
        {
            if (ModelState.IsValid)
            {
                context.Entry(fabricante).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("index");
            }
            return View("fabricante");
        }
        // GET DETALHES
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = context.Fabricantes.Find(id);
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }

        // GET DELETE
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = context.Fabricantes.Find(id);
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }
        // POST DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long Id)
        {
            Fabricante fabricante = context.Fabricantes.Find(Id);
            context.Fabricantes.Remove(fabricante);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}