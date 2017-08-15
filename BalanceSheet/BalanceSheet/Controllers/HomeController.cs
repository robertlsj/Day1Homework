using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BalanceSheet.Models;
using BalanceSheet.Service;
using BalanceSheet.Repositories;

namespace BalanceSheet.Controllers
{
    public class HomeController : Controller
    {
        private readonly BalanceSheetService _balanceSheetService;

        public HomeController()
        {
            var unitOfWork = new EFUnitOfWork();
            _balanceSheetService = new Service.BalanceSheetService(unitOfWork);
        }

        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult BalanceList()
        {
            var result = _balanceSheetService.GetAll();
            return View(result);
        }

        [ChildActionOnly]
        public ActionResult BalanceListQry(BookingViewModels bookingViewModels)
        {
            var result = _balanceSheetService.Query(m => m.Categoryyy == 0 && m.Amounttt > 10000);
            return View("BalanceList", result);
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