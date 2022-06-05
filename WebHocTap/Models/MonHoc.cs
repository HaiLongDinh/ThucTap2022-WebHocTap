using System.ComponentModel.DataAnnotations;

namespace WebHocTap.Models
{
    public class MonHoc
    {
        [Key]
        public Guid ID { get; set; }
        public string TenMonHoc { get; set; }
        public string MoTa { get; set; }
    }
}
