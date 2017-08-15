using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BalanceSheet.Models;
using BalanceSheet.Service;
using System.Data.Entity;

namespace BalanceSheet.Controllers
{
    public class HomeController : Controller
    {
        private readonly BalanceSheetService _balanceService;
        private List<SelectListItem> kindList = new List<SelectListItem>();

        public HomeController()
        {
            _balanceService = new Service.BalanceSheetService();
            kindList.AddRange(new [] { 
                new SelectListItem() { Text = "支出", Value = "0" },
                new SelectListItem() { Text = "收入", Value = "1" }
            });
        }

        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult BalanceList()
        {
            var result = _balanceService.GetAll().Select(m => new BookingViewModels()
            { 
                Kind = kindList.Where(x => x.Value == m.Categoryyy.ToString()).First().Text,
                Amount = m.Amounttt,
                Date = m.Dateee.ToString("yyyy-MM-dd")
            }).OrderBy(m => m.Date).ToList();
            return View(result);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}