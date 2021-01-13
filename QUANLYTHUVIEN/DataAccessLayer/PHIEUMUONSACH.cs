namespace QUANLYTHUVIEN.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUMUONSACH")]
    public partial class PHIEUMUONSACH
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string MADOCGIA { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(200)]
        public string MASACH { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime NGAYMUONSACH { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime NGAYTRA { get; set; }

        public int? SOLUONGMUON { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(20)]
        public string MANHANVIEN { get; set; }

        public virtual DOCGIA DOCGIA { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual SACH SACH { get; set; }
    }
}
