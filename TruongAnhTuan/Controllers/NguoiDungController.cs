using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TruongAnhTuan.Controllers
{
    public class NguoiDungController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        [HttpGet]
        // GET: NguoiDung
        public ActionResult Dangky()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Dangky(FormCollection collection, SinhVien s)
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
                return RedirectToAction("Dangnhap");

            }
            return this.Dangky();

        }

        [HttpGet]
        // GET: NguoiDung
        public ActionResult Dangnhap()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Dangnhap(FormCollection collection)
        {
            var E_masv = collection["MaSV"];
            
            SinhVien s = data.SinhViens.SingleOrDefault(n=>n.MaSV == E_masv);
            if (s != null)
            {
                ViewBag.ThongBao = "Chuc mung dang nhap thanh cong";
                Session["TaiKhoan"] = s;
            }
            else
            {
                ViewBag.ThongBao = "Sai ma sinh vien";

            }
            return RedirectToAction("Index", "HocPhan");

        }
    }
}