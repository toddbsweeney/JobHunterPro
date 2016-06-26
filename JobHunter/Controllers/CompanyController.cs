using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobHunter.DAL;
using JobHunter.Models;
using PagedList;
using System.Data.Entity.Infrastructure;

namespace JobHunter.Controllers
{
    public class CompanyController : Controller
    {
        private JobHunterContext db = new JobHunterContext();

        // GET: Company
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            
            var Companies = from c in db.Companies
                            select c;
            //Do some searching!
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            switch (sortOrder)
            {
                case "Name_desc":
                    Companies = Companies.OrderByDescending(c => c.CompanyName);
                    break;
                default:
                    Companies = Companies.OrderBy(c => c.CompanyName);
                    break;
            }

            int pageSize = 2;
            int pageNumber = (page ?? 1);
            return View(Companies.ToPagedList(pageNumber, pageSize));
        }

        // GET: Company/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // GET: Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyName,AddressOne,AddressTwo,City,State,Zip,PortlandHQ,Website,Employees,Notes")] Company company)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Companies.Add(company);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            } //try
            catch (RetryLimitExceededException /*dex*/)
            {
                //Log the error
                ModelState.AddModelError("", "Unable to save changes.  Try again.  If the problem persists...uhhhh...try to fix it?");
            }

            return View(company);
        }

        // GET: Company/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Company/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            // No ID?  Thats a problem.
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var CompanyToUpdate = db.Companies.Find(id);
            if (TryUpdateModel(CompanyToUpdate, "", new string[] { "CompanyName","AddressOne","AddressTwo","City","State","Zip","PortlandHQ","Website","Notes"}))
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException)
                {
                    ModelState.AddModelError("", "Unable to Save changes...You should probably give up");
                }
            }
            return View(CompanyToUpdate);
        }

        // GET: Company/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError=false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete Failure, try again and again...and again.";
            }

            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Company/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Company company = db.Companies.Find(id);
                db.Companies.Remove(company);
                db.SaveChanges();
            }
            catch (RetryLimitExceededException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }

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
