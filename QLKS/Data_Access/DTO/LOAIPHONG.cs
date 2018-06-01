namespace Data_Access.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity.Spatial;

    [Table("LOAIPHONG")]
    public partial class LOAIPHONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAIPHONG()
        {
            PHONGs = new HashSet<PHONG>();
        }

        public int ID { get; set; }

        public string TEN { get; set; }

        public string ANH { get; set; }
        public string MOTA { get; set; }

        public int? SOGIUONG
        {
            get;
            set;
        }

        public int? DONGIA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHONG> PHONGs { get; set; }

        public LOAIPHONG(DataRow row)
        {
            ID = (int)row["ID"];
            TEN = row["TEN"].ToString();
            ANH = row["ANH"].ToString();
            MOTA = row["MOTA"].ToString();
            SOGIUONG = (int)row["SOGIUONG"];
            DONGIA = (int)row["DONGIA"];
        }
    }
}
