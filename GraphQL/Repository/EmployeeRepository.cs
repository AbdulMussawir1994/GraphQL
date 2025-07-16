using GraphQL.DataDbContext;
using GraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Employee>> GetAllAsync() =>
            await _context.Employees.AsNoTracking().ToListAsync();

        public async Task<Employee?> GetByIdAsync(int id) =>
            await _context.Employees.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

        public async Task<Employee> CreateAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee?> UpdateAsync(int id, Employee updatedEmployee)
        {
            var existing = await _context.Employees.FindAsync(id);
            if (existing is null) return null;

            existing.FullName = updatedEmployee.FullName;
            existing.Email = updatedEmployee.Email;
            existing.Department = updatedEmployee.Department;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee is null) return false;

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
