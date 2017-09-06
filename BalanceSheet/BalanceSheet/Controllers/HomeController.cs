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
    [RoutePrefix("skilltree")]
    [Route("{action=Index}")]
    public class HomeController : Controller
    {
        private readonly BalanceSheetService _balanceSheetService;
        private int pagesize = 10;

        public HomeController()
        {
            var unitOfWork = new EFUnitOfWork();
            _balanceSheetService = new Service.BalanceSheetService(unitOfWork);
        } 

        public ActionResult Login(string year, string month)
        {
            ViewBag.year = year;
            ViewBag.month = month;
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserViewModel model, string year, string month)
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
            ViewBag.year = year;
            ViewBag.month = month;
            return View("Index");
        }

        public ActionResult Index()
        {
            if (Session["username"] == null) return RedirectToAction("Login", new { controller = "Home", area = "" });
            return View();
        }

        [Route("{yyyy:int}/{mm:int}")]
        public ActionResult Index(string yyyy, string mm)
        {
            if (Session["username"] == null) return RedirectToAction("Login", new { controller = "Home", area = "", year = yyyy, month = mm });
            ViewBag.year = yyyy;
            ViewBag.month = mm;
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
        public ActionResult BalanceListQry(string year, string month, int page = 1)
        {
            int currentPage = page;
            var beginDate = new DateTime(Int16.Parse(year), Int16.Parse(month), 1);
            var endDate = new DateTime(Int16.Parse(year), Int16.Parse(month), DateTime.DaysInMonth(Int16.Parse(year), Int16.Parse(month)));
            var result = _balanceSheetService.Query(m => m.Dateee >= beginDate && m.Dateee <= endDate).ToList().Select(m =>
                new BookingViewModels()
                {
                    Id = m.Id.ToString(),
                    Kind = (AccountEnum)m.Categoryyy,
                    Amount = m.Amounttt,
                    Date = m.Dateee.ToString(),
                    Remark = m.Remarkkk
                }).ToPagedList(currentPage, pagesize);

            ViewBag.year = year;
            ViewBag.month = month;
            return PartialView("BalanceList", result);
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