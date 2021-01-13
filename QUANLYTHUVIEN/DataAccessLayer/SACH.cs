namespace QUANLYTHUVIEN.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SACH")]
    public partial class SACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SACH()
        {
            PHIEUMUONSACH = new HashSet<PHIEUMUONSACH>();
        }

        [Key]
        [StringLength(200)]
        public string MASACH { get; set; }

        [Required]
        [StringLength(100)]
        public string TENSACH { get; set; }

        [Required]
        [StringLength(100)]
        public string TENTACGIA { get; set; }

        public int GIA { get; set; }

        public int NAMXUATBAN { get; set; }

        [Required]
        [StringLength(100)]
        public string NHAXUATBAN { get; set; }

        [Required]
        [StringLength(100)]
        public string TINHTRANGSACH { get; set; }

        public DateTime NGAYNHAPSACH { get; set; }

        public int SOLUONG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUMUONSACH> PHIEUMUONSACH { get; set; }
    }
}
