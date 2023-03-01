using FluentValidation;
using FluentValidationExample.Endpoints;
using FluentValidationExample.Services;
using FluentValidationExample.Validators;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<AddStuffEndpoint>();
builder.Services.AddScoped<GetAllTheStuffEndpoint>();
builder.Services.AddScoped<DeleteStuffEndpoint>();
builder.Services.AddScoped<GetStuffByIdEndpoint>();
builder.Services.AddSingleton<IStuffService, StuffService>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddValidatorsFromAssemblyContaining<StuffValidator>();

var app = builder.Build();
app.UseHttpsRedirection();

using (var scope = app.Services.CreateScope()) {
  scope.ServiceProvider.GetService<AddStuffEndpoint>()?.MapEndpoint(app);
  scope.ServiceProvider.GetService<GetAllTheStuffEndpoint>()?.MapEndpoint(app);
  scope.ServiceProvider.GetService<DeleteStuffEndpoint>()?.MapEndpoint(app);
  scope.ServiceProvider.GetService<GetStuffByIdEndpoint>()?.MapEndpoint(app);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.Run();