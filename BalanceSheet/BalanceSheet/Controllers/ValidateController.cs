using System.Web.Mvc;

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