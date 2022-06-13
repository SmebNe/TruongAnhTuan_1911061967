using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TruongAnhTuan.Controllers
{
    public class DangKyController : Controller
    {
        // GET: DangKy
        MyDataDataContext data =   new MyDataDataContext();

        public ActionResult Index()
        {
            return View();
        }
    }
}