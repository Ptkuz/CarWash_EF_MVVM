using System.ComponentModel.DataAnnotations;

namespace CarWash_DB
{
    public class Service
    {
        [Key]
        public Guid IdService { get; set; }
        public string NameService { get; set; }
        public decimal PriceService { get; set; }
        public bool Choise { get; set; }
    }
}
