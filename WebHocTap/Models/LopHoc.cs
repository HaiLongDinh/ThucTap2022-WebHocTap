using System.ComponentModel.DataAnnotations;

namespace WebHocTap.Models
{
    public class LopHoc
    {
        [Key]
        public Guid ID { get; set; }
        public string TenLop { get; set; }
        public User GiaoVien { get; set; }
        public string MoTa { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string ThoiLuong { get; set; }
        public string Status { get; set; }
        public KhoaHoc KhoaHoc { get; set; }
    }
}
