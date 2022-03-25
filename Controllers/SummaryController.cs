using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BigFootWebApp.Models;
using BigFootWebApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace BigFootWebApp.Controllers
{
    [Authorize]
    public class SummaryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult SummaryView()
        {
            var values = db.Interactions.Select(x=>x.DealValue).Sum();
            ViewBag.Values = values;
            return View();
        }
    }
}
