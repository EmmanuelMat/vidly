using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Linq;
using System.Web.Http;
using Vidly.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Vidly.Controllers.Api
{
    public class CustomersController: ControllerBase
    {
        private ApplicationDbContext db; 
        
        public CustomersController(ApplicationDbContext context)        
        {
            
            db = context;
        }
        [Route("api/customers")]
        // GET api/customers
        public IEnumerable<Customer> GetCustomers()
        {
           return db.Customer.ToList();

        }
        [Route("api/customers/{id}")]
        // GET api/customers/1        
        public  ActionResult<Customer> GetCustomers(int id)
            {
                var customer =  db.Customer.SingleOrDefault(c => c.Id == id);

                if (customer == null)
                {
                    return NotFound();
                }

                return customer;
            }

            [HttpPost]
            [Route("api/customers")]
            //POST api/customer
            public ActionResult<Customer> CreateCustomer(Customer customer)
            {
                if(ModelState.IsValid)
                {
                    db.Add(customer);
                    db.SaveChanges();
                }else
                {
                    return BadRequest();
                }

                return customer;
            }

            //PUT api/customer/1
            [HttpPut]
            [Route("api/customers/{id}")]
            public ActionResult<Customer> UpdateCustomer(int id, Customer customer)
            {
                var customerInDb = db.Customer.SingleOrDefault(c => c.Id == id);

                if(customerInDb != null)
                {
                    customerInDb.Name = customer.Name;
                    customerInDb.BirthDay = customer.BirthDay;
                    customerInDb.IsSubscribeToNewletter = customer.IsSubscribeToNewletter;
                    customerInDb.MembershipType = customer.MembershipType;

                    db.SaveChanges();
                }else
                {
                    return NotFound();
                }
                return customerInDb;
            }

            //DELETE api/customer/1
            [HttpDelete]
            [Route("api/customers/{id}")]
            public ActionResult<Customer> DeleteCustomer(int id)
            {
                var customerInDb = db.Customer.SingleOrDefault(c => c.Id == id);
                if(customerInDb != null)
                   {
                       db.Customer.Remove(customerInDb);
                       db.SaveChanges();
                   }else
                   {
                      return NotFound();
                   }
                   return customerInDb;
            }

    }
}