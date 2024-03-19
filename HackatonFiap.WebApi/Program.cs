using HackatonFiap;
using HackatonFiap.Aplicacao;
using HackatonFiap.Dominio;
using HackatonFiap.Infraestrutura;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfraestrutura(builder.Configuration);
builder.Services.AddAplicacao();
builder.Services.AddWebApi();

builder.Services.AddAutoMapper(typeof(Program), typeof(DomainAssembly));

builder.Services.AddControllers();
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
