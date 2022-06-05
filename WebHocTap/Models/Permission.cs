using System.ComponentModel.DataAnnotations;

namespace WebHocTap.Models
{
    public class Permission
    {
        [Key]
        public Guid ID { get; set; }
        public string TenPermission { get; set; }
    }
}
