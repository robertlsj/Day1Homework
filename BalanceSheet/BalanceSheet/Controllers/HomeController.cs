using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using BalanceSheet.Models;
using BalanceSheet.Service;
using BalanceSheet.Repositories;
using PagedList;

namespace BalanceSheet.Controllers
{
    public class HomeController : Controller
    {
        private readonly BalanceSheetService _balanceSheetService;
        private int pagesize = 10;

        public HomeController()
        {
            var unitOfWork = new EFUnitOfWork();
            _balanceSheetService = new Service.BalanceSheetService(unitOfWork);
        } 

        public ActionResult Login()
        { 
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserViewModel model)
        {
            Session["username"] = model.UserName;
            if (_balanceSheetService.UserIsAdmin(model.UserName))
            {
                ViewBag.role = "Admin";
            }
            else
            {
                ViewBag.role = "Users";
            }
            return View("Index");
        }

        public ActionResult Index()
        {
            if (Session["username"] == null) return RedirectToAction("Login", new { controller = "Home", area = "" });
            return View();
        }

        [HttpPost]
        public ActionResult Create(BookingViewModels booking)
        {
            if (ModelState.IsValid)
            {
                _balanceSheetService.Create(booking);
            }

            return View("Index");
        }
        [ChildActionOnly]
        public ActionResult BalanceList(int page = 1)
        {
            int currentPage = page;
            var result = _balanceSheetService.GetAll().OrderByDescending(m => m.Dateee).ToList().Select(m =>
                new BookingViewModels()
                {
                    Id = m.Id.ToString(),
                    Kind = (AccountEnum)m.Categoryyy,
                    Amount = m.Amounttt,
                    Date = m.Dateee.ToString(),
                    Remark = m.Remarkkk
                }).ToPagedList(currentPage, pagesize);

            return PartialView(result);
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