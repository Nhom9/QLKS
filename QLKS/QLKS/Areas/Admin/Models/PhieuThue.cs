using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLKS.Areas.Admin.Models
{
    public class PhieuThue
    {
        public int IDNhanVien { get; set; }
        public int CMND { get; set; }
        public int IDPhong { get; set; }
        public string Ten { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string TenCongTy { get; set; }

        public SelectList DsNhanVien { get; set; }
        public SelectList DsLoaiPhong { get; set; }

        public SelectList DsPhong { get; set; }
    }
}