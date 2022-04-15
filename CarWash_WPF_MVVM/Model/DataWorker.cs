using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWash_DB;

namespace CarWash_WPF_MVVM.Model
{
    public static class DataWorker
    {
        public static List<object> GetAllCars() 
        {
            using (ApplicationContext db = new ApplicationContext()) 
            {
                List<object> cars = new List<object>();

                var result = from car in db.Cars
                             join CarBodys in db.CarBodies on car.Id_CarBody equals CarBodys.IdCarBody
                             orderby car.Manufacturer
                             select new
                             {
                                 Manufacturer = car.Manufacturer,
                                 Model = car.Model,
                                 Year = car.Year,
                                 Body = CarBodys.NameCarBody
                             };

                foreach(var car in result)
                    cars.Add(car);

                return cars;
            
            }
        
        
        }

        public static List<object> GetAllClients() 
        {
            using (ApplicationContext db = new ApplicationContext()) 
            { 
                List<object> clients = new List<object>();

                var result = from client in db.Clients orderby client.FIO select client;

                foreach(var client in result)
                    clients.Add(client);

                return clients;
            }
        
        }

        public static List<object> GetAllOrders() 
        {
            using (ApplicationContext db = new ApplicationContext()) 
            {
                List<object> orders = new List<object>();

                var result = from order in db.Orders
                             join car in db.Cars on order.IdCar equals car.IdCar
                             join client in db.Clients on order.IdClient equals client.IdClient
                             join box in db.Boxes on order.IdBox equals box.IdBox
                             join status in db.Statuses on order.IdStatus equals status.IdStatus
                             orderby order.Dateorder
                             select new 
                             {
                                 IdOrder = order.IdOrder,
                                 DateOrder = order.Dateorder,
                                 Model = car.Model,
                                 FIO = client.FIO,
                                 PhoneNumber = client.PhoneNumber,
                                 Email = client.Email,
                                 BeginDate = order.BeginDate,
                                 EndDate = order.EndDate,   
                                 NumberBox = box.NameBox,
                                 Price = order.Price,
                                 NameStatus = status.NameStatus
                             
                             };
                foreach (var order in result) 
                {
                    orders.Add(order);
                }
                return orders;
            }

        }

        public static List<object> GetAllBoxes() 
        {
            using (ApplicationContext db = new ApplicationContext()) 
            {
                List<object> boxes = new List<object>();

                var result = from box in db.Boxes orderby box.NameBox select box;
                
                foreach (var box in result)
                    boxes.Add(box);
                return boxes;
            
            }
        
        }

        public static List<object> GetAllCarBody() 
        {
            using (ApplicationContext db = new ApplicationContext()) 
            {
                List<object> carBodies = new List<object>();
                var result = from carBody in db.CarBodies orderby carBody.NameCarBody select carBody;
                foreach (var carBody in result)
                    carBodies.Add(carBody);
                return carBodies;
            
            }
        }

        public static List<object> GetAllServices() 
        {
            using (ApplicationContext db = new ApplicationContext()) 
            {
                List<object> services = new List<object>();
                var result = from service in db.Services orderby service.NameService select service;
                foreach (var service in result)
                    services.Add(service);
                return services;
            
            }
        
        }

        public static bool AddCar(string manufacturer, string model, int year, CarBody carBody) 
        { 
            bool result = false;
            using (ApplicationContext db = new ApplicationContext()) 
            {
                Car car = new Car 
                {
                    IdCar = Guid.NewGuid(),
                    Manufacturer = manufacturer,
                    Model = model,
                    Year = year,
                    Id_CarBody = carBody.IdCarBody
                
                };
                db.Cars.Add(car);
                db.SaveChanges();
                result = true;
            }
                return result;
        }
    }
}
