using Company.G02.BLL.Interfaces;
using Company.G02.DAL.Models;
using Company.G02.PL.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Company.G02.PL.Controllers
{
    [Route("Employee")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // Index action to list all employees
        [HttpGet("")]
        public IActionResult Index()
        {
            var employees = _employeeRepository.GetAll();
            return View(employees);
        }

        // Create actions
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateEmployeeDto model)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee
                {
                    // Don't set Id — let the database handle it!
                    Name = model.Name,
                    Address = model.Address,
                    Age = model.Age??0,
                    CreateAt = model.CreateAt,
                    HiringTime = model.HiringTime,
                    Email = model.Email,
                    IsActive = model.IsActive,
                    IsDelete = model.IsDelete,
                    Phone = model.Phone,
                    Salary = model.Salary
                };

                var count = _employeeRepository.Add(employee);
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index)); // Redirect to list
                }
                ModelState.AddModelError("", "Failed to create employee.");
            }
            return View(model); // Return to form if failed
        }


        // Details action
        [HttpGet("Details/{id}")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest("Error in ID");
            }

            var employee = _employeeRepository.Get(id.Value);

            if (employee == null)
            {
                return NotFound(new { StatusCode = 404, message = $"Employee with ID {id} not found" });
            }

            return View(employee);
        }

        // Edit (GET)
        [HttpGet("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var employee = _employeeRepository.Get(id);
            if (employee == null)
            {
                return NotFound(new { StatusCode = 404, message = $"Employee with ID {id} not found" });
            }

            return View(employee);
        }

        // Edit (POST)
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute]int id, CreateEmployeeDto model)
        {
          

            if (ModelState.IsValid)
            {
                var employee = new Employee
                {
                    Id = id,
                    Name = model.Name,
                    Address = model.Address,
                    Age = model.Age ?? 0,
                    CreateAt = model.CreateAt,
                    HiringTime = model.HiringTime,
                    Email = model.Email,
                    IsActive = model.IsActive,
                    IsDelete = model.IsDelete,
                    Phone = model.Phone,
                    Salary = model.Salary
                };

                var count = _employeeRepository.Update(employee);
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index)); // Redirect to index if successful
                }

                ModelState.AddModelError("", "Failed to update employee.");
            }

            return View(model); // Return the form with validation errors if needed
        }

        // Delete (GET)
        [HttpGet("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var employee = _employeeRepository.Get(id);
            if (employee == null)
            {
                return NotFound(new { StatusCode = 404, message = $"Employee with ID {id} not found" });
            }

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = _employeeRepository.Get(id);
            if (employee == null)
            {
                return NotFound();
            }

            _employeeRepository.Delete(employee);
            return RedirectToAction("Index");
        }


    }
}
