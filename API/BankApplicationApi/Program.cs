using BusinessLayer.Interface;
using BusinessLayer.Service;
using DAL.DAL;
using DAL.IDAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ITransactionService,TransactionService>();
builder.Services.AddScoped<IBankService, BankService>();
builder.Services.AddScoped<IBankDAL, BankDALLayer>();
builder.Services.AddScoped<ITransactionDALLayer, TransactionDALLayer>();
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

app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
