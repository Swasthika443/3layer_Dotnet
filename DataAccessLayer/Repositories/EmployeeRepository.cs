using System.Linq;
using DataAccessLayer.DataContext;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories
{
    public class EmployeeRepository
    {
        private readonly CrudMvcContext _dbContext;

        public EmployeeRepository(CrudMvcContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _dbContext.Employees.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return _dbContext.Employees.FirstOrDefault(e => e.Id == id);
        }

        public void AddEmployee(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            var existingEmployee = _dbContext.Employees.FirstOrDefault(e => e.Id == employee.Id);
            if (existingEmployee != null)
            {
                existingEmployee.FirstName = employee.FirstName;
                existingEmployee.LastName = employee.LastName;
                existingEmployee.EmpAge = employee.EmpAge;
                existingEmployee.Mobile = employee.Mobile;

                _dbContext.SaveChanges();
            }
        }

        public void DeleteEmployee(int id)
        {
            var employeeToRemove = _dbContext.Employees.FirstOrDefault(e => e.Id == id);
            if (employeeToRemove != null)
            {
                _dbContext.Employees.Remove(employeeToRemove);
                _dbContext.SaveChanges();
            }
        }
    }
}
