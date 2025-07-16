using FluentValidation;
using GraphQL.Models;
using GraphQL.Repository;

namespace GraphQL.Helpers;


public class EmployeeMutation
{
    public async Task<Employee> CreateEmployee(
           CreateEmployeeInput input,
           [Service] IEmployeeRepository repo,
           [Service] IValidator<CreateEmployeeInput> validator)
    {
        await validator.ValidateAndThrowAsync(input);

        var employee = new Employee
        {
            FullName = input.FullName,
            Email = input.Email,
            Department = input.Department
        };

        return await repo.CreateAsync(employee);
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