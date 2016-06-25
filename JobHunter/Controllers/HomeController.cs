using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobHunter.DAL;
using JobHunter.ViewModels;


namespace JobHunter.Controllers
{
    public class HomeController : Controller
    {
        private JobHunterContext db = new JobHunterContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            IQueryable<CompanyHQGroup> data = from company in db.Companies
                                               group company by company.PortlandHQ into HQGroup
                                               select new CompanyHQGroup()
                                               {
                                                   HQStatus = HQGroup.Key.ToString(),
                                                   CompanyCount = HQGroup.Count()
                                               };

            return View(data.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}