using Microsoft.AspNetCore.Mvc;

namespace KonusarakOgren.CreateExam.MVC.Controllers
{
    public class ExamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
