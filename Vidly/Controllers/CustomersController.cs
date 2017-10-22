using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    
    public class CustomersController : Controller
    {
        // GET: Customers
        
        private ApplicationDbContext _context;
       
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [Route("Customers/Index")]
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c=>c.MembershipType).ToList();
           
            
            return View(customers);
        }
        public ActionResult New()
        {
            var membershipType = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipType
            };
            return View("CustomerForm",viewModel);
        }
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if(customer.Id==0)
                _context.Customers.Add(customer);
            else
            {
                var CustomeInDb = _context.Customers.Single(c => c.Id == customer.Id);
                CustomeInDb.Id = customer.Id;
                CustomeInDb.Name = customer.Name;
                CustomeInDb.Birthdate = customer.Birthdate;
                CustomeInDb.MembershipTypeId = customer.MembershipTypeId;
                CustomeInDb.IsSubscribedToNewsLetters = customer.IsSubscribedToNewsLetters;
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm",viewModel);
        }
        [Route("Customers/Details/{Id}")]
        public ActionResult Details(int Id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == Id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }
    }
}