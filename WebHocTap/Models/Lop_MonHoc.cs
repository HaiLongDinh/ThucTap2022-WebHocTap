using System.ComponentModel.DataAnnotations;

namespace WebHocTap.Models
{
    public class Lop_MonHoc
    {
        [Key]
        public Guid ID { get; set; }
        public LopHoc Lop { get; set; }
        public long SoTiet { get; set; }
        public MonHoc MonHoc { get; set; }
        public DateTime ThoiGian {get; set;}
}
}
