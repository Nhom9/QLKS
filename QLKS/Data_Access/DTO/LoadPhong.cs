namespace Data_Access.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity.Spatial;

    [Table("PHONG")]
    public partial class LoadPhong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoadPhong()
        {
        
        }

        public int ID { get; set; }

        public int IDLOAI { get; set; }

        [StringLength(50)]
        public string TENPHONG { get; set; }

        public byte? STATUS { get; set; }

        public LoadPhong(DataRow row)
        {
            ID = (int)row["ID"];
            IDLOAI = (int)row["IDLOAI"];
            TENPHONG = row["TENPHONG"].ToString();
            STATUS = (byte)row["STATUS"];


        }
    }
}
