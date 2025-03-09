using Company.G02.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.G02.BLL.Interfaces
{
    public interface IGenericRepository<T> where T:BaseEntity
    {
        IEnumerable<T> GetAll();           // Fetch all records
        T? Get(int id);                    // Get a record by ID
        int Add(T model);                  // Add a new record
        int Update(T model);               // Update an existing record
        int Delete(T model);               // Delete a record
    }
}
