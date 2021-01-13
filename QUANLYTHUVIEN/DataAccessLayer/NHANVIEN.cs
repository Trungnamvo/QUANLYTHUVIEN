namespace QUANLYTHUVIEN.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            PHIEUMUONSACH = new HashSet<PHIEUMUONSACH>();
        }

        [Key]
        [StringLength(20)]
        public string MANHANVIEN { get; set; }

        [Required]
        [StringLength(100)]
        public string TENNHANVIEN { get; set; }

        [Required]
        [StringLength(100)]
        public string CHUCVU { get; set; }

        public DateTime NGAYVAOLAM { get; set; }

        public DateTime NGAYSINH { get; set; }

        [Required]
        [StringLength(100)]
        public string GIOITINH { get; set; }

        [Required]
        [StringLength(100)]
        public string DIACHI { get; set; }

        public int? SDT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUMUONSACH> PHIEUMUONSACH { get; set; }
    }
}
