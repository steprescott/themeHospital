using System.Web.Mvc;

namespace TH.WebSystem.Controllers
{
    public class DoctorController : AuthorisedBaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}