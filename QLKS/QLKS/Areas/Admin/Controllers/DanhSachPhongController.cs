using Data_Access.Phong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLKS.Areas.Admin.Controllers
{
    public class DanhSachPhongController : Controller
    {
        ConnectClass cc = new ConnectClass();
        // GET: Admin/DanhSachPhong
        public ActionResult Index()
        {
            return View(cc.LoadPhongTam());
        }
    }
}