using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Quan_ly_vat_tu.Models
{
    public class Kho
    {
        [Key]
        [DisplayName("Mã kho")]
        public int maKho { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Tên kho")]
        public string tenKho { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Địa chỉ")]
        public string diaChi { get; set; }
        public ICollection<VatTu> nVatTu { get; set; }
    }   
}
