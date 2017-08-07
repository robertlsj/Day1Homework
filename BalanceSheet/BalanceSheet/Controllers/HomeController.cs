using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BalanceSheet.Models;

namespace BalanceSheet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult BalanceList()
        {
            IList<BookingViewModels> bookingModels = new List<BookingViewModels>();
            bookingModels.Add(new BookingViewModels()
            {
                Kind = "收入",
                Date = "2017/08/03",
                Amount = 1200
            });

            bookingModels.Add(new BookingViewModels()
            {
                Kind = "支出",
                Date = "2017/08/03",
                Amount = 500
            });

            bookingModels.Add(new BookingViewModels()
            {
                Kind = "支出",
                Date = "2017/08/04",
                Amount = 700
            });

            bookingModels.Add(new BookingViewModels()
            {
                Kind = "收入",
                Date = "2017/08/05",
                Amount = 800
            });

            bookingModels.Add(new BookingViewModels()
            {
                Kind = "支出",
                Date = "2017/08/06",
                Amount = 2000
            });

            return View(bookingModels);
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