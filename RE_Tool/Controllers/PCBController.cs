using dao.Entity;
using System.Web.Mvc;

namespace RE_Tool.Controllers
{
    public class PCBController : Controller
    {
        // GET: PCB
        public ActionResult DanhSach()
        {
            MapSerialNumber map = new MapSerialNumber();
            var ds = map.LoadDetail();
            //var ds = map.LoadPage(1, 20);
            return View(ds);
        }
    }
}