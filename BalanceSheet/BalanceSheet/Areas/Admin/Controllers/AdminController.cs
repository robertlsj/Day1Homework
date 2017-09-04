using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using BalanceSheet.Models;
using BalanceSheet.Service;
using BalanceSheet.Repositories;


namespace BalanceSheet.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private readonly BalanceSheetService _balanceSheetService;

        public AdminController()
        {
            var unitOfWork = new EFUnitOfWork();
            _balanceSheetService = new Service.BalanceSheetService(unitOfWork);
        }

        public ActionResult Delete(string id)
        {
            if (Session["username"] == null) return RedirectToAction("Index", "Home", new {area = ""});
            var result = _balanceSheetService.Query(m => m.Id.ToString() == id).FirstOrDefault();
            return View(result);
        }

        [HttpPost]
        public ActionResult Delete(BookingViewModels model)
        {
            _balanceSheetService.Delete(model);
            return RedirectToAction("Index", "Home", new {area=""});
        }

        public ActionResult Edit(string id)
        {
            if (Session["username"] == null) return RedirectToAction("Index", "Home", new { area = "" });
            var result = _balanceSheetService.Query(m => m.Id.ToString() == id).FirstOrDefault();
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(BookingViewModels model)
        {
            _balanceSheetService.Edit(model);
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [ChildActionOnly]
        public ActionResult BalanceListAdmin()
        {
            var result = _balanceSheetService.GetAll();
            return View(result);
        }
    }
}