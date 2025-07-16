using GraphQL.Models;
using HotChocolate.Types;

namespace GraphQL.Helpers;

public class EmployeeType : ObjectType<Employee>
{
    protected override void Configure(IObjectTypeDescriptor<Employee> descriptor)
    {
        descriptor.Field(e => e.Id).Type<NonNullType<IntType>>();
        descriptor.Field(e => e.FullName).Type<NonNullType<StringType>>();
        descriptor.Field(e => e.Email).Type<NonNullType<StringType>>();
        descriptor.Field(e => e.Department).Type<NonNullType<StringType>>();
    }
}
