namespace Data_Access.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity.Spatial;

    [Table("THUEPHONGLOAD")]
    public partial class THUEPHONGLOAD
    {
        public THUEPHONGLOAD()
        {
        }

        public int ID { get; set; }

        public int IDPHONG { get; set; }

        public int IDNHANVIEN { get; set; }

        public int CMND { get; set; }

        public DateTime? NGAYTHUE { get; set; }

        public DateTime? NGAYDI { get; set; }

        public byte? STATUS { get; set; }

        public int? TONGTIEN { get; set; }
        public string PHONG { get; set; }
        public THUEPHONGLOAD(DataRow row)
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

        }
    }
}
