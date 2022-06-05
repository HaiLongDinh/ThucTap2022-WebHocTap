using System.ComponentModel.DataAnnotations;

namespace WebHocTap.Models
{
    public class ThiKiemTra
    {
        [Key]
        public Guid ID { get; set; }
        public LopHoc Lop { get; set; }
        public DateTime NgayKiemTra { get; set; }
        public MonHoc MonHoc { get; set; }
        public HinhThuc HinhThuc { get; set; }
        public long ThoiLuong { get; set; }
        public string MoTa { get; set; }
        public string NoiDung { get; set; }
        public string File { get; set; }
        public string Status { get; set; }
    }
}
