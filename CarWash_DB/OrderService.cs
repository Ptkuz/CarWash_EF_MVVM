using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash_DB
{
    public class OrderService
    {
        public Guid IdOrder { get; set; }
        public Guid IdService { get; set; }
        public Order? Order { get; set; }
        public Service? Service { get; set; }
    }
}
