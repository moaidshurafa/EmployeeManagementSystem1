using EmployeeManagementSystem1.Data;
using EmployeeManagementSystem1.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _db;
        public EmployeeController(AppDbContext db) 
        { 
            _db = db;
        }
        public IActionResult Index()
        {
            List<Employee> objCategoryList = _db.Employees.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The DisplayOrder cannot match exactly the Name");//the error message
            //}
            if (ModelState.IsValid)
            {
                _db.Employees.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Employee created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Employee? employeeFromDb = _db.Employees.Find(id);
            

            if (employeeFromDb == null)
            {
                return NotFound();
            }
            return View(employeeFromDb);

        }
        [HttpPost]
        public IActionResult Edit(Employee obj)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category edited successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Employee? categoryFromDb = _db.Employees.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);

        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Employee? obj = _db.Employees.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Employees.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
