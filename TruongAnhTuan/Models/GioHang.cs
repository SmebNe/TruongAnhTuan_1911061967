using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruongAnhTuan.Models
{
    public class GioHang
    {
        MyDataDataContext data = new MyDataDataContext();
        public string MaHP { get; set; }
        public string TenHP { get; set; }
        public int SoTinChi { get; set; }
        public GioHang(string id)
        {
            MaHP = id;
            HocPhan hocPhan = data.HocPhans.Single(n => n.MaHP == MaHP);
            TenHP = hocPhan.TenHP;
            SoTinChi = int.Parse(hocPhan.SoTinChi.ToString());
        }

    }
}