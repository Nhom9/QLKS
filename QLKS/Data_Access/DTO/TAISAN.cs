namespace Data_Access.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity.Spatial;

    [Table("TAISAN")]
    public partial class TAISAN
    {
        public int ID { get; set; }

        public string TEN { get; set; }

        public string LOAI { get; set; }

        public int IDPHONG { get; set; }

        public int GIA { get; set; }
        public int SOLUONG { get; set; }
        public bool STATUS { get; set; }

        public DateTime? NGAY { get; set; }

        public virtual PHONG PHONG { get; set; }

        public TAISAN() { }
        public TAISAN(DataRow row)
        {
            ID = (int)row["ID"];
            TEN = row["TEN"].ToString();
            LOAI = row["LOAI"].ToString();
            IDPHONG = (int)row["IDPHONG"];
            int num;
            int.TryParse(row["GIA"].ToString(),out num);
            GIA = num;
            num = 0;
            int.TryParse(row["SOLUONG"].ToString(),out num);
            SOLUONG = num;
            STATUS = false;
            if (row["STATUS"].ToString() == "1")
                STATUS = true;
            NGAY = (DateTime)row["NGAY"];
        }
    }
}
