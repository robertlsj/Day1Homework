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
            IList<BookingViewModels> bookingModels = default(IList<BookingViewModels>);
            BookingViewModels accountRecord1 = new BookingViewModels(){
                Kind = "收入",
                Date = "2017/08/03",
                Amount = 1200
            };
            bookingModels.Add(accountRecord1);

            BookingViewModels accountRecord2 = new BookingViewModels()
            {
                Kind = "支出",
                Date = "2017/08/03",
                Amount = 500
            };
            bookingModels.Add(accountRecord2);

            BookingViewModels accountRecord3 = new BookingViewModels()
            {
                Kind = "支出",
                Date = "2017/08/04",
                Amount = 700
            };
            bookingModels.Add(accountRecord3);

            BookingViewModels accountRecord4 = new BookingViewModels()
            {
                Kind = "收入",
                Date = "2017/08/05",
                Amount = 800
            };
            bookingModels.Add(accountRecord4);

            BookingViewModels accountRecord5 = new BookingViewModels()
            {
                Kind = "支出",
                Date = "2017/08/06",
                Amount = 2000
            };
            bookingModels.Add(accountRecord5);

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