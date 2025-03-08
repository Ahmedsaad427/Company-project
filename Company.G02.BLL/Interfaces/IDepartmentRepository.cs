using Company.G02.DAL.Models;

namespace Company.G02.BLL.Interfaces
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAll();
        Department? Get(int id); // Fetches a department by ID
        int Add(Department model);
        int Delete(Department model);
        int Update(Department model);
    }
}
