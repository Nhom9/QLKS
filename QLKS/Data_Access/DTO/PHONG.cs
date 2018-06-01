namespace Data_Access.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity.Spatial;

    [Table("PHONG")]
    public partial class PHONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHONG()
        {
            ///CHITIETTHUEPHONGs = new HashSet<CHITIETTHUEPHONG>();
            TAISANs = new HashSet<TAISAN>();
        }

        public int ID { get; set; }

        public int IDLOAI { get; set; }

        [StringLength(50)]
        public string TENPHONG { get; set; }

        public byte? STATUS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        ///public virtual ICollection<CHITIETTHUEPHONG> CHITIETTHUEPHONGs { get; set; }

        public virtual LOAIPHONG LOAIPHONG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TAISAN> TAISANs { get; set; }

        public PHONG(DataRow row)
        {
            ID = (int)row["ID"];
            IDLOAI = (int)row["IDLOAI"];

            TENPHONG = row["TENPHONG"].ToString();
            STATUS = (byte)row["STATUS"];

        }
    }
}
