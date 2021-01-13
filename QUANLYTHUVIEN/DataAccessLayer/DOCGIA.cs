namespace QUANLYTHUVIEN.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DOCGIA")]
    public partial class DOCGIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DOCGIA()
        {
            PHIEUMUONSACH = new HashSet<PHIEUMUONSACH>();
        }

        [Key]
        [StringLength(20)]
        public string MADOCGIA { get; set; }

        [Required]
        [StringLength(100)]
        public string TENDOCGIA { get; set; }

        public DateTime NGAYSINH { get; set; }

        public DateTime NGAYLAPTHE { get; set; }

        public DateTime NGAYHETHAN { get; set; }

        [Required]
        [StringLength(100)]
        public string DIACHI { get; set; }

        [StringLength(100)]
        public string EMAIL { get; set; }

        [Required]
        [StringLength(100)]
        public string GIOITINH { get; set; }

        public long PHIGIAHANTHE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUMUONSACH> PHIEUMUONSACH { get; set; }
    }
}
