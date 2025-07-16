using GraphQL.Models;
using GraphQL.Repository;
using HotChocolate;

namespace GraphQL.Helpers;

public class EmployeeQuery
{
    public async Task<IEnumerable<Employee>> GetEmployees([Service] IEmployeeRepository repository) =>
        await repository.GetAllAsync();

    public async Task<Employee?> GetEmployeeById(int id, [Service] IEmployeeRepository repository) =>
        await repository.GetByIdAsync(id);
}