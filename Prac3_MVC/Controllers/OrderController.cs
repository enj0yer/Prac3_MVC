using System.Collections.Generic;
using System.Web.Mvc;
using Prac3_MVC.Models;

namespace Prac3_MVC.Controllers
{
    public class OrderController : Controller
    {
        OrderContext db = new OrderContext();

        public ActionResult Index()
        {
            return View("Order");
        }

        [HttpPost]
        public ActionResult Add(Order model)
        {
            db.Orders.Add(model);

            if (db.Customers.Find(model.CustomerId) != null)
            {
                db.Customers.Find(model.CustomerId).COO += 1;
            }

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Add()
        {
            Order model = new Order();

            return View(model);
        }

        [HttpGet]
        public ActionResult Check()
        {
            return View(db.Orders);
        }

        [HttpPost]
        public ActionResult Delete(Order model)
        {
            if (db.Orders.Find(model.Id) == null)
            {
                return RedirectToAction("Index");
            }
            else
            {

                if (db.Orders.Find(model.Id) != null)
                {

                    if (db.Customers.Find(db.Orders.Find(model.Id).CustomerId) == null)
                    {
                        db.Orders.Remove(db.Orders.Find(model.Id));

                    }
                    else
                    {
                        db.Customers.Find(db.Orders.Find(model.Id).CustomerId).COO -= 1;
                        db.Orders.Remove(db.Orders.Find(model.Id));
                    }
                    
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id != null && db.Orders.Find(id) == null)
            {
                return HttpNotFound();
            }
            else if (id != null)
            {
                if (db.Orders.Find(id) != null)
                {
                    if (db.Customers.Find(db.Orders.Find(id).CustomerId) == null)
                    {
                        db.Orders.Remove(db.Orders.Find(id));
                    }
                    else
                    {
                        db.Customers.Find(db.Orders.Find(id).CustomerId).COO -= 1;
                        db.Orders.Remove(db.Orders.Find(id));
                    }
                    
                    
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            else
            {
                Order model = new Order();
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Modify(Order model)
        {
            if (db.Orders.Find(model.Id) == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                Order order = db.Orders.Find(model.Id);
                if (order != null)
                {
                    if (model.Name != null) order.Name = model.Name;
                    if (model.CustomerId > 0) order.CustomerId = model.CustomerId;
                    if (model.Price > 0) order.Price = model.Price;

                    db.SaveChanges();
                }
               
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Modify()
        {
            Order model = new Order();
            return View(model);
        }


    }
}