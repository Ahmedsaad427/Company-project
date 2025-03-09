using Company.G02.BLL.Interfaces;
using Company.G02.DAL.Data.Contexts;
using Company.G02.DAL.Models;

namespace Company.G02.BLL.Repos
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(CompanyDbContext context) : base(context)
        {
        }
    }
}
