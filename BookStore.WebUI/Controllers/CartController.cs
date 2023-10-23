using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Cart()
        {
            return View();
        }
    }
}
