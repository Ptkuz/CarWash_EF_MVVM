﻿using System.ComponentModel.DataAnnotations;
namespace CarWash_DB
{
    public class CarBody
    {
        [Key]
        public Guid IdCarBody { get; set; }
        public string NameCarBody { get; set; }
        List<Car> Cars { get; set; } = new();

    }
}
