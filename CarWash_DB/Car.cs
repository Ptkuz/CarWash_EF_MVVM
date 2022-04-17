using System.ComponentModel.DataAnnotations;

namespace CarWash_DB
{
    public class Car
    {
        [Key]
        public Guid IdCar { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Id_CarBody { get; set; }
        public CarBody? CarBody { get; set; } 


    }
}
