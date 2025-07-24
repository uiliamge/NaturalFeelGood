using Amazon.DynamoDBv2.DataModel;
using FluentValidation;
using MediatR;
using NaturalFeelGood.Api.Messages;
using NaturalFeelGood.Api.Middleware;
using NaturalFeelGood.Application.Behaviors;
using NaturalFeelGood.Application.Features.ElementTypes.Commands;
using NaturalFeelGood.Application.Features.ElementTypes.Mappings;
using NaturalFeelGood.Application.Validators;
using NaturalFeelGood.Domain.Interfaces;
using NaturalFeelGood.Infrastructure;
using NaturalFeelGood.Infrastructure.Repositories;
using NaturalFeelGood.Infrastructure.Seed;

var builder = WebApplication.CreateBuilder(args);

// 1. Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(ElementTypeProfile).Assembly);
builder.Services.AddValidatorsFromAssemblyContaining<CreateElementTypeDtoValidator>();
builder.Services.AddSingleton<IErrorMessageProvider, JsonErrorMessageProvider>();

// 2. Application (MediatR, Behaviors, etc)
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateElementTypeCommand>());
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

// 3. Infrastructure (Dynamo, repos, etc)
builder.Services.AddInfrastructure();
builder.Services.AddScoped<IElementTypeRepository, ElementTypeRepository>();

// 4. Build app
var app = builder.Build();

// 5. Seeder
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<IDynamoDBContext>();
    await ElementTypeSeeder.SeedAsync(context);
}

// 6. Middlewares
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
