using System.ComponentModel.DataAnnotations;

namespace EvolveApp.Data.Models
{
    public class Business
    {
        public int Index { get; set; }
        [StringLength(200)]
        public string Code { get; set; } = String.Empty;
        [StringLength(200)]
        public string Name { get; set; } = String.Empty;
        public bool IsDelete { get; set; }
        [StringLength(200)]
        public string CreateUser { get; set; } = String.Empty;
        public DateTime CreatedDate { get; set; }
        [StringLength(200)]
        public string ModifiedUser { get; set; } = String.Empty;
        public DateTime ModifiedDate { get; set; }
        [StringLength(200)]
        public string DeletedUser { get; set; } = String.Empty;
        public DateTime DeletedDate { get; set; }
    }
}
