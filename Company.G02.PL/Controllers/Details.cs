﻿using Company.G02.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Company.G02.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        // Action to show department details
        public IActionResult Details(int id)
        {
            var department = _departmentRepository.Get(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }
    }
}
