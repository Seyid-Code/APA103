using Microsoft.AspNetCore.Mvc;

namespace _25_MVC_Intro.Controllers
{
    public class HomeController: Controller
    {
        public ViewResult Index()
        {
            return View("Index");
        }

        public ViewResult Detail(int? id)
        {
        //    if (id is null || id < 1 )
        //    {
        //        throw new Exception("Id sehvdir");
        //    }
            return View();
        }

        public ViewResult Error()
        {
            return View();
        }
    }
}
