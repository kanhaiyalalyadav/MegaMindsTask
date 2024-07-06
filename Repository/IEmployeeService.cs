using MegaMindsTask.Models;

namespace MegaMindsTask.Repository
{
    public interface IEmployeeService
    {
        int Add(Employee emp); 
        IEnumerable<Employee> GetAllEmployee();
        Employee GetById(int id);
        int Delete(int Id);
    }
}
