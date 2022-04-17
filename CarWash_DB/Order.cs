using System.ComponentModel.DataAnnotations;

namespace CarWash_DB
{
    public class Order
    {
        [Key]
        public Guid IdOrder { get; set; }
        public Guid IdCar { get; set; }
        public Car? Car { get; set; }
        public Guid IdClient { get; set; }
        public Client? Client { get; set; }
        public DateTime Dateorder { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int IdBox { get; set; }
        public Box? Box { get; set; }
        public int Discount { get; set; }
        public decimal Price { get; set; }
        public int IdStatus { get; set; }
        public Status? Status { get; set; }


    }
}
