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

    // Helper method to get department or return proper error response
    private IActionResult GetDepartmentView(int? id, string viewName)
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

        return View(viewName, department);
    }

    // Details action
    [HttpGet("Details/{id}")]
    public IActionResult Details(int? id)
    {
        return GetDepartmentView(id, "Details");
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

    // Edit (GET)
    [HttpGet("Edit/{id}")]
    public IActionResult Edit(int? id)
    {
        return GetDepartmentView(id, "Edit");
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
            var count = _departmentRepository.Update(department);
            if (count > 0)
            {
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError("", "Failed to update department.");
        }

        return View(department);
    }

    // Delete (GET)
    [HttpGet("Delete/{id}")]
    public IActionResult Delete(int? id)
    {
        return GetDepartmentView(id, "Delete");
    }

    // Delete (POST)
    [HttpPost("Delete/{id}")]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id, Department department)
    {
        if (id != department.Id)
        {
            return BadRequest("ID mismatch.");
        }

        if (ModelState.IsValid)
        {
            var count = _departmentRepository.Delete(department);
            if (count > 0)
            {
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError("", "Failed to delete department.");
        }

        return View(department);
    }
}
