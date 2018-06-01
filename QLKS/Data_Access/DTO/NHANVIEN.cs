namespace Data_Access.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity.Spatial;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            THUEPHONGs = new HashSet<THUEPHONG>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string USERNAME { get; set; }

        [StringLength(50)]
        public string PASS { get; set; }

        [StringLength(50)]
        public string TENHIENTHI { get; set; }

        public byte? CHUCVU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THUEPHONG> THUEPHONGs { get; set; }
        ///DataProvider.Instance.ExcuteQuery("pLogin @username , @pass ", new object[] { username, pass}).Rows[0]
        public NHANVIEN(DataRow row)
        {
            ID = (int)row["ID"];
            USERNAME = row["USERNAME"].ToString();
            PASS = row["PASS"].ToString();
            TENHIENTHI = row["TENHIENTHI"].ToString();
            CHUCVU = (byte)row["CHUCVU"];
        }
    }
}
