using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Quan_ly_vat_tu.Models
{
    public class VatTu
    {
        [Key]
        public int maVatTu { get; set; }

        [Required]
        [Column(TypeName="nvarchar(100)")]
        [System.ComponentModel.DisplayName("Tên vật tư")]
        public string tenVatTu { get; set; }
        [Column(TypeName ="int")]
        [System.ComponentModel.DisplayName("Số lượng")]
        public int soLuong { get; set; }
        [Column(TypeName="float")]
        [System.ComponentModel.DisplayName("Giá")]
        public float gia { get; set; }
        [System.ComponentModel.DisplayName("Mã kho")]
        public int maKho { get; set; }
        public Kho kho { get; set; }
    }
}
