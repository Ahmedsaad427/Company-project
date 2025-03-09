using Microsoft.AspNetCore.Mvc;
using Company.G02.BLL.Interfaces;

namespace Company.G02.PL.Controllers
{
    public class DeleteController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DeleteController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public IActionResult Index(int id)
        {
            var department = _departmentRepository.Get(id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            var department = _departmentRepository.Get(id);
            if (department == null)
            {
                return NotFound();
            }

            _departmentRepository.Delete(department);

            // 🚀 Redirect to the Department list after successful delete
            return RedirectToAction("Index", "DepartmentControllers");
        }
    }
}
