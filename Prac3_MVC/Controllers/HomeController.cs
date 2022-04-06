using Prac3_MVC.Models;
using System.Web.Mvc;

namespace Prac3_MVC.Controllers
{
    public class HomeController : Controller
    {
        OrderContext db = new OrderContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Result()
        {
            return View();
        }
    }
}