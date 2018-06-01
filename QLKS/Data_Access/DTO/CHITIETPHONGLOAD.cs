namespace Data_Access.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity.Spatial;

    [Table("CHITIETPHONGLOAD")]
    public partial class CHITIETPHONGLOAD
    {
        public int ID { get; set; }

        public string HOTEN { get; set; }

        public int CMND { get; set; }

        public bool TRUONGPHONG { get; set; }

        public int IDCT { get; set; }
        public string TenPhong { get; set; }
        public int SoDienThoai { get; set; }
        public CHITIETPHONGLOAD() { }
        public CHITIETPHONGLOAD(DataRow row)
        {
            ID = (int)row["ID"];
            HOTEN = (string)row["HOTEN"];
            int num = 0;
            int.TryParse(row["CMND"].ToString(), out num);
            CMND = num;
            TRUONGPHONG = row["TRUONGPHONG"].ToString() == "1" ? true : false ;
            IDCT = (int)row["IDCT"];
            TenPhong = (string)row["TenPhong"];
            int num1 = 0;
            int.TryParse(row["SDT"].ToString(), out num1);
            SoDienThoai = num1;
            
        }
        //public virtual CHITIETTHUEPHONG CHITIETTHUEPHONG { get; set; }
    }
}
