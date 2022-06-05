using System.ComponentModel.DataAnnotations;

namespace WebHocTap.Models
{
    public class Lop_SinhVien
    {
        [Key]
        public Guid ID { get; set; }
        public LopHoc Lop { get; set; }
        public User SinhVien { get; set; }
    }
}
