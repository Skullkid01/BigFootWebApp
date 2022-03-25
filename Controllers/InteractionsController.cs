using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BigFootWebApp.Models;
using BigFootWebApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace BigFootWebApp.Controllers
{
    [Authorize]
    public class InteractionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Interactions
        public ActionResult Index()
        {
            var interactions = db.Interactions.Include(i => i.Customer);
            return View(interactions.ToList());
        }

        // GET: Interactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Interaction interaction = db.Interactions.Find(id);
            interaction.Customer = db.Customers.Find(interaction.CustomerId);
            if (interaction == null)
            {
                return NotFound();
            }
            return PartialView(interaction);
        }

        // GET: Interactions/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "CustomerName");
            return PartialView();
        }

        // POST: Interactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Interaction interaction)
        {
            if (ModelState.IsValid)
            {
                db.Interactions.Add(interaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "CustomerName", interaction.CustomerId);
            return View(interaction);
        }

        // GET: Interactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Interaction interaction = db.Interactions.Find(id);
            if (interaction == null)
            {
                return NotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "CustomerName", interaction.CustomerId);
            return PartialView(interaction);
        }

        // POST: Interactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Interaction interaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "CustomerName", interaction.CustomerId);
            return View(interaction);
        }

        // GET: Interactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Interaction interaction = db.Interactions.Find(id);
            interaction.Customer = db.Customers.Find(interaction.CustomerId);
            if (interaction == null)
            {
                return NotFound();
            }
            return PartialView(interaction);
        }

        // POST: Interactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Interaction interaction = db.Interactions.Find(id);
            db.Interactions.Remove(interaction);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
