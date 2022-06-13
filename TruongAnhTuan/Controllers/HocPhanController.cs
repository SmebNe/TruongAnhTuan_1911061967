using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TruongAnhTuan.Controllers
{
    public class HocPhanController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();

        // GET: HocPhan
        public ActionResult Index()
        {
            var all_hocphan = from s in data.HocPhans select s;
            return View(all_hocphan);
        }
    }
}