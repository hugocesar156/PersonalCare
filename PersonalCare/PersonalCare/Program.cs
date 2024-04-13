using Microsoft.OpenApi.Models;
using PersonalCare.IoC;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("geral", new OpenApiInfo
    {
        Version = "v1",
        Title = "Geral",
        Description = "Rotas gerais para registros do sistema."
    });
    options.SwaggerDoc("acesso", new OpenApiInfo
    {
        Version = "v1",
        Title = "Acesso",
        Description = "Rotas de controle de acesso."
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/geral/swagger.json", "Geral");
        options.SwaggerEndpoint("/swagger/acesso/swagger.json", "Acesso");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
