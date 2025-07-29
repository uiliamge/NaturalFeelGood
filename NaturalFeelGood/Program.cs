using Amazon.DynamoDBv2.DataModel;
using Application.Common.Interfaces;
using Application.Features.ElementTypes.Validators;
using FluentValidation;
using MediatR;
using NaturalFeelGood.Api.Implementations;
using NaturalFeelGood.Api.Middleware;
using NaturalFeelGood.Api.Middlewares;
using NaturalFeelGood.Application.Behaviors;
using NaturalFeelGood.Application.Features.ElementTypes.Commands;
using NaturalFeelGood.Application.Features.ElementTypes.Mappings;
using NaturalFeelGood.Application.Validators;
using NaturalFeelGood.Domain.Common;
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


builder.Services.AddSingleton<IErrorMessageProvider, ErrorMessageProvider>();

// 2. Application (MediatR, Behaviors, etc)
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateElementTypeCommand>());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<DeleteElementTypeCommand>());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Command>());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateMedicationCommand>());
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateProblemCommand>());
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateOrganCommand>());
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateBodySystemCommand>());
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateSymptomCommand>());
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateNaturalElementCommand>());

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddScoped<UserLanguage>();

// 2.1. FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<CreateElementTypeDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<DeleteElementTypeCommandValidator>();

// 3. Infrastructure (Dynamo, repos, etc)
builder.Services.AddInfrastructure();
builder.Services.AddScoped<IElementTypeRepository, ElementTypeRepository>();

// 4. Build app
var app = builder.Build();

// 5. Seeder
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<IDynamoDBContext>();
    var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
    var s3BaseUrl = configuration.GetSection("S3Settings:BaseUrl").Value
                    ?? throw new InvalidOperationException("S3Settings:BaseUrl is not configured.");
    await ElementTypeSeeder.SeedAsync(context, s3BaseUrl);
}

// 6. Middlewares
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<LanguageMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
