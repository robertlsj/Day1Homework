using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BalanceSheet.Models;

namespace BalanceSheet.Controllers
{
    public class ValidateController : Controller
    {
        public ActionResult GreaterThenbasenum(int Amount, int basenum)
        {
            bool isValidate = (Amount > basenum);
            return Json(isValidate, JsonRequestBehavior.AllowGet);
        }
    }
}