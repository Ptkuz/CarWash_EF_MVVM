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

        public static List<object> GetAllCarsWithOrder()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<object> cars = new List<object>();

                var res = from car in db.Cars orderby car.Manufacturer select car;

                foreach (var car in res)
                    cars.Add(car);


                return cars;

            }


        }

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
                                 IdCar = car.IdCar,
                                 Manufacturer = car.Manufacturer,
                                 Model = car.Model,
                                 Year = car.Year,
                                 Body = CarBodys.NameCarBody
                             };

                foreach (var car in result)
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

        public static bool AddClient(string fio, string carNumber, string phoneNumber, string email) 
        {
            bool result = false;
            using (ApplicationContext db = new ApplicationContext()) 
            {
                Client client = new Client
                {
                    IdClient = Guid.NewGuid(),
                    FIO = fio,
                    CarNumber = carNumber,
                    PhoneNumber = phoneNumber,
                    Email = email
                };
                db.Clients.Add(client);
                db.SaveChanges();
                result=true;
            }
            return result;
        
        }

        public static bool AddOrder(Car car, Client client, DateTime beginDate, DateTime endDate, Box box, int discount, decimal price)
        {
            bool result = false;
            using (ApplicationContext db = new ApplicationContext())
            {
                Order order = new Order
                {
                    IdOrder = Guid.NewGuid(),
                    IdCar = car.IdCar,
                    IdClient = client.IdClient,
                    Dateorder = DateTime.Now,
                    BeginDate = beginDate,
                    EndDate = endDate,
                    IdBox = box.IdBox,
                    Discount = discount,
                    Price = price,
                    IdStatus = 1
                };
                db.Orders.Add(order);
                db.SaveChanges();
                result = true;
            }
            return result;

        }

        public static bool AddBox(string nameBox) 
        {
            bool result = false;
            using (ApplicationContext db = new ApplicationContext()) 
            {
                Box box = new Box
                {
                    NameBox = nameBox
                };
                db.Boxes.Add(box);
                db.SaveChanges();
                result = true;
            }
            return result;
        }

        public static bool AddCarBody(string nameCarBody) 
        {
            bool result = false;
            using (ApplicationContext db = new ApplicationContext()) 
            {
                CarBody carBody = new CarBody
                {
                    NameCarBody = nameCarBody
                };
                db.CarBodies.Add(carBody);
                db.SaveChanges();   
                result=true;
            }
            return result;
        
        }

        public static bool AddService(string nameService, decimal priceService) 
        {
            bool result = false;
            using (ApplicationContext db = new ApplicationContext()) 
            {
                Service service = new Service
                {
                    NameService = nameService,
                    PriceService = priceService
                };
                db.Services.Add(service);
                db.SaveChanges();
                result = true;
            }
            return result;
        }
    }
}
