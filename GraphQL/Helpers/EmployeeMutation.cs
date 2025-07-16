using FluentValidation;
using GraphQL.Models;
using GraphQL.Repository;
using HotChocolate;

namespace GraphQL.Helpers;


public class EmployeeMutation
{
    public async Task<Employee> CreateEmployee(Employee input,
        [Service] IEmployeeRepository repo,
        [Service] IValidator<Employee> validator)
    {
        await validator.ValidateAndThrowAsync(input);
        return await repo.CreateAsync(input);
    }

    public async Task<Employee?> UpdateEmployee(int id, Employee input,
        [Service] IEmployeeRepository repo,
        [Service] IValidator<Employee> validator)
    {
        await validator.ValidateAndThrowAsync(input);
        return await repo.UpdateAsync(id, input);
    }

    public async Task<bool> DeleteEmployee(int id, [Service] IEmployeeRepository repo) =>
        await repo.DeleteAsync(id);
}