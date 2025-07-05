using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Добавляем DbContext
builder.Services.AddDbContext<SessiaApi.DataBaseContext.SessiaCarServiceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TestDbString")));

builder.Services.AddScoped<SessiaApi.Interfaces.IUserService, SessiaApi.Services.UserService>();
builder.Services.AddScoped<SessiaApi.Interfaces.ICarService, SessiaApi.Services.CarService>();
builder.Services.AddScoped<SessiaApi.Interfaces.IRepairRequestService, SessiaApi.Services.RepairRequestService>();
builder.Services.AddScoped<SessiaApi.Interfaces.IPartService, SessiaApi.Services.PartService>();
builder.Services.AddScoped<SessiaApi.Interfaces.IRepairPartService, SessiaApi.Services.RepairPartService>();
builder.Services.AddScoped<SessiaApi.Interfaces.IChatMessageService, SessiaApi.Services.ChatMessageService>();
builder.Services.AddScoped<SessiaApi.Interfaces.IPaymentService, SessiaApi.Services.PaymentService>();
builder.Services.AddSignalR();

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
app.MapHub<SessiaApi.ChatHub>("/chathub");

app.Run();
