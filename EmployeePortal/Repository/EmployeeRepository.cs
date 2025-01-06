using EmployeePortal.Data;
using EmployeePortal.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeePortal.Repository
{
    public class EmployeeRepository
    {
        private readonly AppDbContext db;

        public EmployeeRepository(AppDbContext db)
        {
            this.db = db;
        }

        //acceddere alla lista dei dipendente
        public async Task<List<Employee>> GetAllEmployees()
        {
            return await db.Employees.ToListAsync();
        }

        //aggiungere un dipendente
        public async Task SaveEmployee(Employee emp)
        {
            await db.Employees.AddAsync(emp);
            await db.SaveChangesAsync();
        }

        //modifier un dipendente
        public async Task updateEmployee(int id, Employee obj)
        {
            var employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new Exception("Employee Not Found");
            }
            employee.Name = obj.Name;
            employee.Email = obj.Email;
            employee.Phone = obj.Phone;
            employee.Age = obj.Age;
            employee.Salary = obj.Salary;
            employee.Status = obj.Status;

            await db.SaveChangesAsync();
        }

        //cancellare un dipendente
        public async Task DeleteEmployee(int id)
        {
            var employee = await db.Employees.FindAsync(id);
            if(employee == null)
            {
                throw new Exception("Employee Not Found");
            }
            db.Employees.Remove(employee);
            await db.SaveChangesAsync();
        }
    }
}
