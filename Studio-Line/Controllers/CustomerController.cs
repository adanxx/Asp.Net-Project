using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Studio_Line.Models;
using System.Data.Entity;
using Studio_Line.ViewModels;
using System.Data.Entity.Validation;

namespace Studio_Line.Controllers
{
    [Authorize] //Adding asp.identity attribute/filter to contrain-access
    public class CustomerController : Controller
    {
        private ApplicationDbContext _contextDb;

        public CustomerController()
        {
            _contextDb = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
           _contextDb.Dispose();
        }

        // GET: Customer
        public ActionResult Index()
        {

            var customers = _contextDb.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _contextDb.Customers.Include(c=> c.MembershipType).SingleOrDefault(c => c.Id == id);

            if(customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        public ActionResult NewCustomer()
        {
            ViewData["FormTitle"] = " New Customer";

            var Membershipstypes = _contextDb.Memebershiptypes.ToList();

            var viewModel = new NewCustomerViewModels
            {
                Memebershipstypeslist = Membershipstypes,
                Customer = new Customers()

            };

            return View("NewFormCustomer",viewModel);
        }
       
        [HttpPost]
        public ActionResult SaveCustomer( NewCustomerViewModels NewCustomer)
        {
           
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModels
                {
                    Memebershipstypeslist = _contextDb.Memebershiptypes.ToList(),
                    Customer = NewCustomer.Customer
                };

                  return View("NewFormCustomer", viewModel);
            }

            if (NewCustomer.Customer.Id == 0)
            {
                _contextDb.Customers.Add(NewCustomer.Customer);
            }
            else
            {
                var customerDb = _contextDb.Customers.Single(c => c.Id == NewCustomer.Customer.Id);

                //TryUpdateModel(customerDb);
                
               
                customerDb.Name = NewCustomer.Customer.Name;
                customerDb.Email = NewCustomer.Customer.Email;
                customerDb.Birthday = NewCustomer.Customer.Birthday;
                customerDb.MembershipTypeId = NewCustomer.Customer.MembershipTypeId;
                customerDb.IsSubcriptedToNewsLetter = NewCustomer.Customer.IsSubcriptedToNewsLetter;
               
            }

            _contextDb.SaveChanges();
           /*/ 
            try
            {
                _contextDb.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            } 
            /*/
            return RedirectToAction("Index", "Customer");
       
        }

        public ActionResult Edit(int Id)
        {
            ViewData["FormTitle"] = " Edit Customer";

            var customer = _contextDb.Customers.SingleOrDefault(c => c.Id == Id);

            if(customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new NewCustomerViewModels
            {
                Customer = customer,
                Memebershipstypeslist = _contextDb.Memebershiptypes.ToList()
            }; 

            return View("NewFormCustomer", viewModel);
        }

        public ActionResult Delete(int id)
        {
            var customer = _contextDb.Customers.SingleOrDefault(c => c.Id == id);

            if(customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                _contextDb.Customers.Remove(customer);
            }

            _contextDb.SaveChanges();

            return RedirectToAction("index", "Customer");


        }

    
    }
}


        /*/
     private IEnumerable<Customers> GetCustomers()
       {
            return new List<Customers>
            {
                new Customers { Id = 1, Name = "John Smith" },
                new Customers { Id = 2, Name = "Mary Williams" }
                
           };
       }
       /*/