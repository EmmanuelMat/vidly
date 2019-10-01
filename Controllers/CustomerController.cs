using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext db;

        public CustomerController(ApplicationDbContext context)
        {
            db = context;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Customer customer)
        {

            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipType = db.MembershipType.ToList()
                };
                return View("CustomerForm", viewModel);                    
            }
            if(customer.Id == 0)
            db.Add(customer);
            else
            {
            var customerInDb = db.Customer.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDay = customer.BirthDay;
                customerInDb.IsSubscribeToNewletter = customer.IsSubscribeToNewletter;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;



            }
            db.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
        public IActionResult New()
        {
            var membershipType = db.MembershipType.ToList();
             var newCustomerViewModel = new CustomerFormViewModel
             {
                  MembershipType = membershipType,
                  Customer =  new Customer()
             };
            return View("CustomerForm",newCustomerViewModel);
        }
       public IActionResult Index()
       {
           var customer  =  db.Customer.Include(c => c.MembershipType).ToList();
           return View(customer);
       }

       public IActionResult Detail(int id)
       {
           var customer = db.Customer.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
           if(customer == null)
            return Content("not found");
           return View(customer);
       }

       public IActionResult Edit(int id)
       {
           var customer = db.Customer.SingleOrDefault(c => c.Id == id);
           if(customer == null)
           return Content("not found");

           var ViewModel = new CustomerFormViewModel
           {
              Customer = customer,
              MembershipType = db.MembershipType.ToList()
           };
           return View("CustomerForm", ViewModel);

       }
    
    }
}
