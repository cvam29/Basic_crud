using Basic_crud.Data;
using Basic_crud.Models;
using Microsoft.AspNetCore.Mvc;

namespace Basic_crud.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Customer> objCatlist = _context.Customers;
            return View(objCatlist);
            
        }
        [HttpGet]
        public IActionResult Create()
        { 
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer cust)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(cust);
                _context.SaveChanges();
                return RedirectToAction("Index");
                TempData["ResultOk"] = "Customer Added Successfully";
            }
            return View(cust);
        }
        public IActionResult Edit(int? id)
        {   
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var customerfromdb = _context.Customers.Find(id);
            if (customerfromdb == null)
            {
                return NotFound();
            }
            return View(customerfromdb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer cust)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Update(cust);
                _context.SaveChanges();
                TempData["ResultOk"] = "Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(cust);

        }
        public IActionResult DeleteCust(int? id)
        {   var deletecustomer=_context.Customers.Find(id);
            if(deletecustomer == null)
            {
                return NotFound();
            }
            _context.Customers.Remove(deletecustomer);
            _context.SaveChanges();
            TempData["ResultOk"] = "Data Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
