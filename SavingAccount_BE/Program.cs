using Microsoft.EntityFrameworkCore;
using SavingAccount_BE.Data;
using SavingAccount_BE.Service.Users.Cards;
using SavingAccount_BE.Service.Users.Histories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IUserCard,UserCard>();
builder.Services.AddTransient<IUserHistory, UserHistory>();
builder.Services.AddDbContext<SavingAccountDbContext>(
    option =>
    {
        option.UseSqlServer(builder.Configuration.GetConnectionString("UsersDatabase"));
    }
);
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(
    builder =>
    {
        builder
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    }
);


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
