namespace Data_Access.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity.Spatial;

    [Table("SDDVLOAD")]
    public partial class SDDVLOAD
    {
        public int ID { get; set; }

        public int IDDV { get; set; }
        public string SERVICES { get; set; }
        public int IDCT { get; set; }
        public string PHONG { get; set; }
        public int? SOLUONG { get; set; }

        public int? TONGTIEN { get; set; }

        public DateTime? NGAY { get; set; }

        public SDDVLOAD() { }
        public SDDVLOAD(DataRow row)
        {
            ID = (int)row["ID"];
            IDDV = (int)row["IDDV"];
            IDCT = (int)row["IDCT"];
            SOLUONG = (int)row["SOLUONG"];
            TONGTIEN = (int)row["TONGTIEN"];
            NGAY = (DateTime)row["NGAY"];
            SERVICES = (string)row["Services"];
            PHONG = (string)row["PHONG"];
        }
    }
}
