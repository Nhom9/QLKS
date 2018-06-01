using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLKS.Areas.Admin.Models
{
    public class NhanVienModel
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string USERNAME { get; set; }

        [StringLength(50)]
        public string PASS { get; set; }

        [StringLength(50)]
        public string TENHIENTHI { get; set; }

        public byte? CHUCVU { get; set; }
    }
}