using System.ComponentModel.DataAnnotations;

namespace CarWash_DB
{
    public class Client
    {
        [Key]
        public Guid IdClient { get; set; }
        public string FIO { get; set; }
        public string CarNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        List<Order> Orders { get; set; } = new();


    }
}