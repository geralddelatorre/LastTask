using CodeFirstEF.Context;
using CodeFirstEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CodeFirstEF.Controllers
{
    public class OrdersController : Controller
    {
        private CustomerContext db = new CustomerContext();
        // GET: Orders
        public ActionResult Index()
        {

            ViewBag.Title = "Order Details";
            //var customers = db.Customers.ToList();
            var customers = db.Customers.ToList();
            var customerModel = customers.Select(c => new CustomerDTO
            {
                Id = c.Id,
                Name = $"{c.Lastname}, {c.Firstname} {c.Middlename}"
            }).ToList();

            SelectList CustomerList = new SelectList(customerModel, "Id", "Name");
            ViewData["CustomerList"] = CustomerList;
            return View();
        }
        public ActionResult _Orderlist(int id = 0)
        {
            var customers = db.Customers.ToList();
            var customerModel = customers.Select(c => new CustomerDTO
            {
                Id = c.Id,
                Firstname = c.Firstname,
                Middlename = c.Middlename,
                Lastname = c.Lastname,
                Birthday = c.Birthday,
                Gender = c.Gender,
                Age = c.Age,
                Address = c.Address,
                EmailAddress = c.EmailAddress,
                Status = c.Status,
                Name = $"{c.Lastname}, {c.Firstname} {c.Middlename}"
            }).ToList();

            var orderList = db.Orders.Where(x => x.CustomerId == id || id == 0).ToList();
            var modelOrder = orderList.Select(c => new OrderDTO
            {
                Id = c.Id,
                No = c.No,
                OrderName = c.OrderName,
                OrderDate = c.OrderDate,
                CustomerId = c.CustomerId,
                Amount = c.Amount,
                Customer = customerModel.FirstOrDefault(x => x.Id == c.CustomerId)
            }).ToList();

            return PartialView("_Orderlist", modelOrder);
        }
    


        // GET: Orders/Details/5
        

        // GET: Orders/Create
        public ActionResult Create()
        {
            var customers = db.Customers.ToList();
            var customerModel = customers.Select(c => new CustomerDTO
            {
                Id = c.Id,
                Name = $"{c.Lastname}, {c.Firstname} {c.Middlename}"
            }).ToList();

            SelectList CustomerList = new SelectList(customerModel, "Id", "Name");
            ViewData["CustomerId"] = CustomerList;
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        public ActionResult Create(Order data, CustomerDTO cus)
        {
            var order = new Order
            {

                No = data.No,
                
                
                OrderDate = data.OrderDate,
                CustomerId = data.CustomerId,
                Amount = data.Amount,
                
            };

            using (db)
            {
                
                db.Orders.Add(order);
                db.SaveChanges();


            }
            return RedirectToAction("Index");
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int id)
        {
            var order = db.Orders.FirstOrDefault(c => c.Id == id);
            order.Items = db.OrdersItems.Where(x => x.OrderId == id).ToList();

            var order_item = order.Items.Select(s => new Orders_ItemsDTO
            {
                Id = s.Id,
                OrderId = s.OrderId,
                ProductId = s.ProductId,
                ProductCode = s.ProductCode,
                ProductName = s.ProductName,
                
                Price = s.Price,
                Amount = s.Amount,
            }).ToList();

            var model = new OrderDTO
            {
                Id = order.Id,
                No = order.No,
                OrderName = order.OrderName,
                OrderDate = order.OrderDate,
                CustomerId = order.CustomerId,
                Amount = order.Amount
                
            };

            var customers = db.Customers.ToList();
            var customerModel = customers.Select(c => new CustomerDTO
            {
                Id = c.Id,
                Name = $"{c.Lastname}, {c.Firstname} {c.Middlename}"
            }).ToList();
            SelectList CustomerList = new SelectList(customerModel, "Id", "Name", model.CustomerId);
            ViewData["CustomerId"] = CustomerList;

            return View(model);
        }
            
        

        // POST: Orders/Edit/5
        [HttpPost]
        public ActionResult Edit(OrderDTO data)
        {
            using (var db = new CustomerContext())
            {
                
                var order = new Order
                {
                    Id = data.Id,
                    No = data.No,
                    OrderName = data.OrderName,
                    OrderDate = data.OrderDate,
                    CustomerId = data.CustomerId,
                    Amount = data.Amount
                };
                var toDelete = db.OrdersItems.Where(x => x.OrderId == order.Id).ToList();
                db.OrdersItems.RemoveRange(toDelete);

                

                var entity = db.Orders.FirstOrDefault(x => x.Id == data.Id);
                db.Entry(entity).CurrentValues.SetValues(order);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var order = db.Orders.FirstOrDefault(c => c.Id == id);
            order.Items = db.OrdersItems.Where(x => x.OrderId == id).ToList();

            var order_item = order.Items.Select(s => new Orders_ItemsDTO
            {
                Id = s.Id,
                OrderId = s.OrderId,
                ProductId = s.ProductId,
                ProductCode = s.ProductCode,
                ProductName = s.ProductName,

                Price = s.Price,
                Amount = s.Amount,
            }).ToList();

            

            var customers = db.Customers.ToList();
            var customerModel = customers.Select(c => new CustomerDTO
            {
                Id = c.Id,
                Name = $"{c.Lastname}, {c.Firstname} {c.Middlename}"
            }).ToList();
            var model = new OrderDTO
            {
                Id = order.Id,
                No = order.No,
               
                OrderDate = order.OrderDate,
                CustomerId = order.CustomerId,
                Amount = order.Amount,
                
                
            };
            
            SelectList CustomerList = new SelectList(customerModel, "Id", "Name", model.CustomerId);
            
            ViewData["CustomerId"] = CustomerList;
            

            return View(model);
        


        }

       




        // GET: Orders/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Orders/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
