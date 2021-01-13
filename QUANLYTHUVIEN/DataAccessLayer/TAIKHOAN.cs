namespace QUANLYTHUVIEN.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAIKHOAN")]
    public partial class TAIKHOAN
    {
        [Key]
        [StringLength(100)]
        public string TENDANGNHAP { get; set; }

        [StringLength(100)]
        public string TENHIENTHI { get; set; }

        [StringLength(1000)]
        public string MATKHAU { get; set; }

        [StringLength(1000)]
        public string XACNHANMATKHAU { get; set; }

        [Required]
        [StringLength(100)]
        public string MALOAI { get; set; }

        public virtual LOAITAIKHOAN LOAITAIKHOAN { get; set; }
    }
}
