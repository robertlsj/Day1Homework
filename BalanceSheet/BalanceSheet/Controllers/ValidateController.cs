using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BalanceSheet.Controllers
{
    public class ValidateController : Controller
    {
        public ActionResult GreaterThenZero(int Amount)
        {
            bool isValidate = (Amount > 0);
            return Json(isValidate, JsonRequestBehavior.AllowGet);
        }
    }
}