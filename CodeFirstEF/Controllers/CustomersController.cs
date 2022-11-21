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
    public class CustomersController : Controller
    {
        CustomerContext db = new CustomerContext();
        // GET: Customers
        public ActionResult Index()
        {
            ViewBag.Title = "Customer List";
            var list = db.Customers.ToList();
            var model = list.Select(c => new CustomerDTO
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
                Status = c.Status
            }).ToList();

            return View(model);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [HttpGet]
        // GET: Customers/Create
        public ActionResult Create()
        {
            
            return View();
            
        }
        [HttpPost]
        // POST: Customers/Create
        
        public ActionResult Create(Customer data)
        {
            var customer = new Customer
            {
                Id = data.Id,
                Firstname = data.Firstname,
                Middlename = data.Middlename,
                Lastname = data.Lastname,
                Birthday = data.Birthday,
                Gender = data.Gender,
                Age = data.Age,
                Address = data.Address,
                EmailAddress = data.EmailAddress,
                Status = data.Status
            };

            db.Customers.Add(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            Customer model = new Customer();
            model = db.Customers.FirstOrDefault(x => x.Id == id);
            return View(model);
            
        }

        // POST: Customers/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer data)
        {
            using (var db = new CustomerContext())
            {
                var entity = db.Customers.FirstOrDefault(x => x.Id == data.Id);
                db.Entry(entity).CurrentValues.SetValues(data);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // POST: Customers/Delete/5
        
        
    }
}
