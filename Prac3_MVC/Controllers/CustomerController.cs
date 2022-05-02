using System.Web.Mvc;
using Prac3_MVC.Models;
using System.Data.Entity;

namespace Prac3_MVC.Controllers
{
    public class CustomerController : Controller
    {

        OrderContext db = new OrderContext();

        public ActionResult Index()
        {
            return View("Customer");
        }

        [HttpPost]
        public ActionResult Add(Customer model)
        {
            db.Customers.Add(model);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Add()
        {
            Customer model =  new Customer();
            return View(model);
        }

        [HttpGet]
        public ActionResult Check()
        {
            return View(db.Customers);
        }

        [HttpPost]
        public ActionResult Delete(Customer model)
        {
            if (db.Customers.Find(model.Id) == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                if (db.Customers.Find(model.Id) != null)
                {
                    db.Customers.Remove(db.Customers.Find(model.Id));
                    db.Orders.SqlQuery("Delete from Orders where CustomerId = @p0", model.Id);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {   
            if (id != null && db.Customers.Find(id) == null)
            {
                return HttpNotFound();
            }
            else if (id != null)
            {

                if (db.Customers.Find(id) != null && db.Customers.Remove(db.Customers.Find(id)) != null)
                {
                    db.Customers.Remove(db.Customers.Find(id));
                    db.Orders.SqlQuery("Delete from Orders where CustomerId = @p0", id);
                    db.SaveChanges();
                }
                
                return RedirectToAction("Index");
            }

            else
            {
                Customer model = new Customer();
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Modify(Customer model)
        {
            if (db.Customers.Find(model.Id) == null){
                return RedirectToAction("Index");
            }
            else
            {
                Customer customer = db.Customers.Find(model.Id);
                if (customer != null)
                {
                    if (model.Name != null) customer.Name = model.Name;
                    if (model.Age > 0) customer.Age = model.Age;
                    if (model.PhoneNumber != null) customer.PhoneNumber = model.PhoneNumber;
                    db.SaveChanges();
                }
               
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public ActionResult Modify()
        {
            Customer model = new Customer();
            return View(model);
        }
    }
}