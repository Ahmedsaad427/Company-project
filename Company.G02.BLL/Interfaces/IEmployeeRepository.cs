using Company.G02.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.G02.BLL.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        //IEnumerable<Employee> GetAll();
        //Employee? Get(int id); // Fetches a department by ID
        //int Add(Employee model);
        //int Delete(Employee model);
        //int Update(Employee model);
    }
}
