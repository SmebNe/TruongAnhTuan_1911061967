using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TruongAnhTuan.Controllers
{
    public class SinhVienController : Controller
    {
        // GET: SinhVien
        MyDataDataContext data = new MyDataDataContext();   
        public ActionResult Index()
        {
            var all_sinhvien = from s in data.SinhViens select s;
            return View(all_sinhvien);
        }
        //public ActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Create(FormCollection collection, SinhVien s)
        //{
        //    var E_masinhvien = collection["MaSV"];
        //    var E_hoten = collection["HoTen"];
        //    var E_gioitinh = collection["GioiTinh"];
        //    var E_ngaysinh = Convert.ToDateTime(collection["NgaySinh"]);
        //    var E_hinh = collection["Hinh"];
        //    var E_manganh = collection["MaNganh"];

        //    if (string.IsNullOrEmpty(E_masinhvien))
        //    {
        //        ViewData["Error"] = "Don't empty!";
        //    }
        //    else
        //    {
        //        s.MaSV = E_masinhvien.ToString();
        //        s.HoTen = E_hoten.ToString();
        //        s.GioiTinh = E_gioitinh.ToString();
        //        s.NgaySinh = E_ngaysinh;
        //        s.Hinh = E_hinh.ToString();
        //        s.MaNganh = E_manganh.ToString();
        //        data.SinhViens.InsertOnSubmit(s);
        //        data.SubmitChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return this.Create();
        //}
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, SinhVien s)
        {
            var E_masv = collection["MaSV"];
            var E_tensinhvien = collection["HoTen"];
            var E_gioitinh = collection["GioiTinh"];
            var E_ngaysinh = Convert.ToDateTime(collection["NgaySinh"]);

            var E_hinh = collection["Hinh"];
            var E_manganh = collection["MaNganh"];

            if (string.IsNullOrEmpty(E_tensinhvien))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                s.MaSV = E_masv.ToString();
                s.HoTen = E_tensinhvien.ToString();
                s.GioiTinh = E_gioitinh.ToString();
                s.NgaySinh = E_ngaysinh;
                s.Hinh = E_hinh;
                s.MaNganh = E_manganh;
                data.SinhViens.InsertOnSubmit(s);
                data.SubmitChanges();
                return RedirectToAction("List");
            }
            return this.Create();
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName));
            return "/Content/images/" + file.FileName;
        }

        public ActionResult Edit(string id)
        {
            var E_sinhvien = data.SinhViens.First(m => m.MaSV == id);
            return View(E_sinhvien);
        }
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            var E_masinhvien = data.SinhViens.First(m => m.MaSV == id);
            var E_hoten = collection["HoTen"];
            var E_gioitinh = collection["GioiTinh"];
            var E_ngaysinh = Convert.ToDateTime(collection["NgaySinh"]);
            var E_hinh = collection["Hinh"];
            var E_manganh = collection["MaNganh"];
            E_masinhvien.MaSV = id;
            if (string.IsNullOrEmpty(E_hoten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_masinhvien.HoTen = E_hoten;
                E_masinhvien.GioiTinh = E_gioitinh;
                E_masinhvien.NgaySinh = E_ngaysinh;
                E_masinhvien.Hinh = E_hinh;
                E_masinhvien.MaNganh = E_manganh;
                UpdateModel(E_masinhvien);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }
        //-----------------------------------------
        public ActionResult Delete(string id)
        {
            var D_sinhvien = data.SinhViens.First(m => m.MaSV == id);
            return View(D_sinhvien);
        }
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            var D_sinhvien = data.SinhViens.Where(m => m.MaSV == id).First();
            data.SinhViens.DeleteOnSubmit(D_sinhvien);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Detail(string id)
        {
            var D_sinhvien = data.SinhViens.Where(m => m.MaSV == id).First();
            return View(D_sinhvien);
        }
    }
}
