namespace Data_Access.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity.Spatial;

    [Table("CHITIETPHONG")]
    public partial class CHITIETPHONG
    {
        public int ID { get; set; }

        public string HOTEN { get; set; }

        [StringLength(11)]
        public string CMND { get; set; }

        public bool TRUONGPHONG { get; set; }

        public int IDCT { get; set; }
        public int SDT { get; set; }
        public CHITIETPHONG() { }
        public CHITIETPHONG(DataRow row)
        {
            ID = (int)row["ID"];
            HOTEN = (string)row["HOTEN"];
            CMND = (string)row["CMND"];
            TRUONGPHONG = (row["TRUONGPHONG"].ToString()) == "1" ? true : false ;
            IDCT = (int)row["IDCT"];
            SDT = (int)row["SDT"];
        }
        //public virtual CHITIETTHUEPHONG CHITIETTHUEPHONG { get; set; }
    }
}
