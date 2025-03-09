// DepartmentController.cs

using Company.G02.BLL.Interfaces;
using Company.G02.DAL.Models;
using Microsoft.AspNetCore.Mvc;

[Route("Department")]
public class DepartmentController : Controller
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentController(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    // Index action to list all departments
    [HttpGet("")]
    public IActionResult Index()
    {
        var departments = _departmentRepository.GetAll();
        return View(departments);
    }

    // Create actions
    [HttpGet("Create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("Create")]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Department department)
    {
        if (ModelState.IsValid)
        {
            _departmentRepository.Add(department);
            return RedirectToAction("Index");
        }
        return View(department);
    }

    // Details action
    [HttpGet("Details/{id}")]
    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return BadRequest("Error in ID");
        }

        var department = _departmentRepository.Get(id.Value);

        if (department == null)
        {
            return NotFound(new { StatusCode = 404, message = $"Department with ID {id} not found" });
        }

        return View(department);
    }

    // Edit (GET)
    [HttpGet("Edit/{id}")]
    public IActionResult Edit(int id)
    {
        var department = _departmentRepository.Get(id);
        if (department == null)
        {
            return NotFound(new { StatusCode = 404, message = $"Department with ID {id} not found" });
        }

        return View(department);
    }

    // Edit (POST)
    [HttpPost("Edit/{id}")]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Department department)
    {
        if (id != department.Id)
        {
            return BadRequest("ID mismatch.");
        }

        if (ModelState.IsValid)
        {
            if (id==department.Id)
            {
                var count = _departmentRepository.Update(department);
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Failed to update department.");
            }
        }
        return View(department);
    }
}
