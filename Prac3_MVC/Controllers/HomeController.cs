using Prac3_MVC.Models;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Prac3_MVC.Controllers
{
    public class HomeController : Controller
    {
        OrderContext db = new OrderContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CheckAll()
        {
            List<CustomerWithOrders> cwo = new List<CustomerWithOrders>();
            var orders = db.Orders.SqlQuery("Select * from Orders").ToListAsync();
            orders.Wait();
            foreach (Customer customer in db.Customers)
            {
                CustomerWithOrders customerWithOrders = new CustomerWithOrders();
                customerWithOrders.Customer = customer;

                var currOrders = orders.Result.FindAll(el => el.CustomerId == customer.Id);
                customerWithOrders.Orders = currOrders;        

                cwo.Add(customerWithOrders);
            }
            return View(cwo);
        }
    }
}