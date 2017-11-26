using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Studio_Line.Models;

namespace Studio_Line.Controllers.ApiControllers
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _contextDb;

        public CustomersController()
        {
            _contextDb = new ApplicationDbContext();
        }

        //Get api/Customers
        public IEnumerable<Customers> GetCustomers()
        {
            var customers = _contextDb.Customers.ToList();
            return customers;
        }

        //Get: api/Customers/id
        public Customers GetCustomers(int Id)
        {
            var customers = _contextDb.Customers.SingleOrDefault(c => c.Id == Id);

            if(customers  == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return customers;
        }


        //Post: api/Customers
        [HttpPost]
        // Can use a build in asp convention and rename the method PostSomthing and remove the HttpPost-attribute at the top
        public Customers PostCustomer(Customers customer)
        {
            if(!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }else
            {
                _contextDb.Customers.Add(customer);
                _contextDb.SaveChanges();
            }
            return customer;
            
        }
        //Update: api/customer/id
        [HttpPut]
        public Customers UpdateCustomer(int id,Customers customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customerDb = _contextDb.Customers.SingleOrDefault(c => c.Id == id);

            if(customerDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
                customerDb.Name = customer.Name;
                customerDb.Email = customer.Email;
                customerDb.Birthday = customer.Birthday;
                customerDb.IsSubcriptedToNewsLetter = customer.IsSubcriptedToNewsLetter;
                customerDb.MembershipTypeId = customer.MembershipTypeId;

               // _contextDb.Customers.Add(customerDb);
                _contextDb.SaveChanges();

            return customerDb;
        }

        // Delete api/customer/id
        [HttpDelete]
        public void Delete(int Id)
        {
            var customerDb = _contextDb.Customers.SingleOrDefault(c => c.Id == Id);

            if (customerDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                _contextDb.Customers.Remove(customerDb);
                _contextDb.SaveChanges();
            }
        }


    }
}
