using Company.G02.BLL.Interfaces;
using Company.G02.BLL.Repos;
using Company.G02.DAL.Models;
using Company.G02.PL.Dtos;
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
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateDepartmnetDto model)
        {
            if (ModelState.IsValid)
            {
                var department = new Department()
                {
                    Code = model.Code,
                    Name = model.Name,
                    CreateAt = model.CreateAt

                };

              var count=  _departmentRepository1.Add(department);
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }



    }



}
