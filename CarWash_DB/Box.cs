using System.ComponentModel.DataAnnotations;

namespace CarWash_DB
{
    public class Box
    {
        [Key]
        public Guid IdBox { get; set; }
        public string NameBox { get; set; }
        List<Order> Orders { get; set; } = new();
    }
}
