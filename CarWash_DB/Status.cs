using System.ComponentModel.DataAnnotations;

namespace CarWash_DB
{
    public class Status
    {
        [Key]
        public int IdStatus { get; set; }
        public string NameStatus { get; set; }
        List<Order> Orders { get; set; } = new();
    }
}
