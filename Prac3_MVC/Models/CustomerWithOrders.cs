using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prac3_MVC.Models
{
    public class CustomerWithOrders
    {
        public Customer Customer { get; set; }
        public List<Order> Orders { get; set; }
    }
}