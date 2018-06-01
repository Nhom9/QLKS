namespace Data_Access.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETTHUEPHONG")]
    public partial class CHITIETTHUEPHONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CHITIETTHUEPHONG()
        {
            CHITIETPHONGs = new HashSet<CHITIETPHONG>();
            SDDVs = new HashSet<SDDV>();
        }

        public int ID { get; set; }

        public int IDMATHUE { get; set; }

        public int IDPHONG { get; set; }

        public DateTime? NGAYTHUE { get; set; }

        public int? NGAYO { get; set; }

        public DateTime? NGAYDI { get; set; }

        public int? TIEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETPHONG> CHITIETPHONGs { get; set; }

        public virtual THUEPHONG THUEPHONG { get; set; }

        public virtual PHONG PHONG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SDDV> SDDVs { get; set; }
        
    }
}
