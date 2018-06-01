using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.DTO
{
    public class KHACHHANG
    {
        public KHACHHANG() { }

        [StringLength(11)]
        public int CMND { get; set; }

        public string TEN { get; set; }

        public string DIACHI { get; set; }

        public string DIENTHOAI { get; set; }

        public string TENCONGTY { get; set; }
        public KHACHHANG(DataRow row)
        {
    
            TEN = row["TEN"].ToString();
            CMND = (int)row["CMND"];
            DIACHI = row["DIACHI"].ToString();
            DIENTHOAI = row["DIENTHOAI"].ToString();
            TENCONGTY = row["TENCONGTY"].ToString();
        }

    }
}
