using System.ComponentModel.DataAnnotations;

namespace EvolveApp.Data.Models
{
    public class UserAccount
    {
        public int Index { get; set; }
        [StringLength(200)]
        public string UserName { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public bool IsActive { get; set; }
        [StringLength(200)]
        public string CreateUser { get; set; } = String.Empty;
        public DateTime CreatedDate { get; set; }
        [StringLength(200)]
        public string ModifiedUser { get; set; } = String.Empty;
        public DateTime ModifiedDate { get; set; }
    }
}
