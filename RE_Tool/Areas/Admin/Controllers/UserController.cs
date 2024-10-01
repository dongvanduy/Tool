using dao.Entity;
using RE_Tool.App_Start;
using System.Web.Mvc;

namespace RE_Tool.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/Login

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            MapAccount map = new MapAccount();
            var user = map.searchAccount(username, password);
            if (user != null)
            {
                
                SessionConfig.SetUser(user);
                return RedirectToAction("Index", "Home", new { area = "Admin" });
                //return Redirect("/Admin/Home/Index");
            }
            ViewBag.error = "Ten dang nhap or mat khau khong dung";
            return View();
        }
        public ActionResult Logout() {
            SessionConfig.SetUser(null);
            return RedirectToAction("Login", "User", new { area = "Admin" });
        }
    }
}