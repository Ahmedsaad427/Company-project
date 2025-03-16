using AutoMapper;
using Company.G02.PL.Dtos;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Company.G02.DAL.Models;
namespace Company.G02.PL.Mapping
{
    //CLR
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {

            CreateMap<CreateEmployeeDto, Employee>().ForMember(d => d.Name, o=>o.MapFrom(s=>s.EmpName));
            CreateMap<Employee, CreateEmployeeDto>();

        }
    }
}
