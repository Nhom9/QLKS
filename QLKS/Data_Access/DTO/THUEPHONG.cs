namespace Data_Access.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity.Spatial;

    [Table("THUEPHONG")]
    public partial class THUEPHONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THUEPHONG()
        {
            ///CHITIETTHUEPHONGs = new HashSet<CHITIETTHUEPHONG>();
        }

        public int ID { get; set; }

        public int IDPHONG { get; set; }

        public int IDNHANVIEN { get; set; }
        
        public int CMND { get; set; }

        public DateTime? NGAYTHUE { get; set; }

        public DateTime? NGAYDI { get; set; }

        public byte? STATUS { get; set; }

        public int? TONGTIEN { get; set; }
        
        public THUEPHONG (DataRow row)
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
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<CHITIETTHUEPHONG> CHITIETTHUEPHONGs { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
