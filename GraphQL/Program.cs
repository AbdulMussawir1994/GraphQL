using GraphQL.DataDbContext;
using GraphQL.Helpers;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.CommandTimeout((int)TimeSpan.FromMinutes(1).TotalSeconds)
    )
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
);

builder.Services.AddApplicationServices();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<EmployeeQuery>()
    .AddMutationType<EmployeeMutation>()
    .AddType<EmployeeType>()
    .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true);


var app = builder.Build();

app.UseDeveloperExceptionPage();

app.UsePlayground(new PlaygroundOptions
{
    QueryPath = "/api",
    Path = "/PlayGround"
});

app.MapGraphQL("/api");

app.Run();