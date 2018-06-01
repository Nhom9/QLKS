using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.DTO
{
    public class ThanhToanPhong
    {
        public ThanhToanPhong()
        {
        }
        public KHACHHANG TTKH = new KHACHHANG();
        public List<SDDVLOAD> Sddv = new List<SDDVLOAD>();
        public List<CHITIETPHONGLOAD> Chitietphong = new List<CHITIETPHONGLOAD>();
        public PHONG phong = new PHONG();
        public ThanhToanPhong(List<SDDVLOAD> list)
        {
            Sddv = list;
        }
        public int NgayO { get; set; }
        public int GiaNgay { get; set; }
        public int ID { get; set; }
        public int IDPHONG { get; set; }
        public int IDNhanVien { get; set; }
        public int CMND { get; set; }
        public DateTime NgayThue { get; set; }
        public DateTime NgayDi { get; set; }
        public bool Status { get; set; }
        public int TongTienDichVu { get; set; }
        public int TongTien { get; set; }
        
        public ThanhToanPhong(DataRow row)
        {
            NgayO = (int)row["NgayO"];
            GiaNgay = (int)row["GiaNgay"];
            ID = (int)row["ID"];
            IDPHONG = (int)row["IDPHONG"];
            IDNhanVien = (int)row["IDNHANVIEN"];
            CMND = (int)row["CMND"];
            NgayThue = (DateTime)row["NgayThue"];
            NgayDi = (DateTime)row["NGAYTHANHTOAN"];
            Status = (row["status"].ToString() == "0") ? false : true ;
            TongTien = NgayO*GiaNgay;
        }

        /*
        public int IDPHIEU { get; set; }

        public int IDPHONG { get; set; }
        public string TENPHONG { get; set; }
        public int IDNHANVIEN { get; set; }
        public string NHANVIEN { get; set; }

        public int CMND { get; set; }
        public string HOTEN { get; set; }
        public string SDT { get; set;}
        public string DIACHI { get; set; }
        public string 
        public DateTime? NGAYTHUE { get; set; }

        public DateTime? NGAYDI { get; set; }

        public byte? STATUS { get; set; }

        public int? TONGTIEN { get; set; }
        public string PHONG { get; set; }
        public List<SDDVLOAD> sddv { get; set; }
        public ThanhToanPhong(DataRow row)
        {
            ID = (int)row["ID"];
            NGAYTHUE = (DateTime?)row["NGAYTHUE"];
            var dayCheckOutTemp = row["NGAYDI"];
            if (dayCheckOutTemp.ToString() != "")
            {
                NGAYDI = (DateTime?)dayCheckOutTemp;

            }
            IDNHANVIEN = (int)row["IDNHANVIEN"];
            STATUS = (byte)row["STATUS"];
            TONGTIEN = (int)row["TONGTIEN"];
            PHONG = (string)row["PHONG"];
            IDPHONG = (int)row["IDPHONG"];
            CMND = (int)row["CMND"];


        }*/

    }
}
