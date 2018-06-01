namespace Data_Access.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity.Spatial;

    [Table("DICHVU")]
    public partial class DICHVU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DICHVU()
        {
            SDDVs = new HashSet<SDDV>();
        }

        public int ID { get; set; }

        public string TEN { get; set; }

        public int? GIA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SDDV> SDDVs { get; set; }

        public DICHVU(DataRow row)
        {
            ID = (int)row["id"];
            GIA= (int)row["gia"];
            TEN = row["ten"].ToString();
        }
    }
}
