using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUD_Demo_MVS.Models;

namespace CRUD_Demo_MVS.Controllers
{
    public class UsersController : Controller
    {
        private MyDBDemoEntities db = new MyDBDemoEntities();

        // GET: Users
        public async Task<ActionResult> Index()
        {
            return View(await db.tblUsers.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUsers tblUsers = await db.tblUsers.FindAsync(id);
            if (tblUsers == null)
            {
                return HttpNotFound();
            }
            return View(tblUsers);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,name,email,address")] tblUsers tblUsers)
        {
            if (ModelState.IsValid)
            {
                db.tblUsers.Add(tblUsers);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tblUsers);
        }

        // GET: Users/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUsers tblUsers = await db.tblUsers.FindAsync(id);
            if (tblUsers == null)
            {
                return HttpNotFound();
            }
            return View(tblUsers);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,name,email,address")] tblUsers tblUsers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblUsers).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tblUsers);
        }

        // GET: Users/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUsers tblUsers = await db.tblUsers.FindAsync(id);
            if (tblUsers == null)
            {
                return HttpNotFound();
            }
            return View(tblUsers);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tblUsers tblUsers = await db.tblUsers.FindAsync(id);
            db.tblUsers.Remove(tblUsers);
            await db.SaveChangesAsync();
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
