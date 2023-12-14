using Microsoft.AspNetCore.Mvc;

namespace api.Lista.PRO.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public JsonResult Index()
        {
            return Json("funcionando");
        }
    }
}
