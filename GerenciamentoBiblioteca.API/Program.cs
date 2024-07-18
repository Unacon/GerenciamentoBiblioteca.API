using GerenciamentoBiblioteca.Application.Queries.GetAllLivros;
using GerenciamentoBiblioteca.Core.Repositories;
using GerenciamentoBiblioteca.Infrastructure.Pesistence;
using GerenciamentoBiblioteca.Infrastructure.Pesistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetAllLivrosQuery).Assembly));

builder.Services.AddScoped<ILivrosRepository, LivrosRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

string connectionString = builder.Configuration.GetConnectionString("GerenciamentoBiblioteca");
builder.Services.AddDbContext<GerenciamentoBibliotecaDbContext>(
    options => options.UseSqlServer(connectionString)
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
