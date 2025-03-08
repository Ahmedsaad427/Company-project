using Company.G02.BLL.Interfaces;
using Company.G02.BLL.Repos;
using Microsoft.AspNetCore.Mvc;

namespace Company.G02.PL.Controllers
{
    //MVC Controller
    public class DepartmentControllers : Controller
    {
        private readonly IDepartmentRepository _departmentRepository1;
        // ASK CLR to create object from DepartmentRepository
        public DepartmentControllers(IDepartmentRepository departmentRepository)
        {
            _departmentRepository1 = departmentRepository;
        }
        public IActionResult Index()
        {
            var department = _departmentRepository1.GetAll();

            return View(department);
        }
    }
}
