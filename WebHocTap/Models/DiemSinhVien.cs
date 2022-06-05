using System.ComponentModel.DataAnnotations;

namespace WebHocTap.Models
{
    public class DiemSinhVien
    {
        [Key]
        public Guid ID { get; set; }
        public User SinhVien { get; set; }
        public LopHoc Lop { get; set; }
        public MonHoc Mon { get; set; }
        public HinhThuc HinhThuc { get; set; }
        public DateTime NgayKT { get; set; }
        public String FilePath { get; set; }
        public double Diem { get; set; }
    }
}
