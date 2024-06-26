using HR.LeaveManagement.Application;
using HR.LeaveManagement.Persistence;
using HR.LeaveManagement.Identity;
using HR.LeaveManagement.Api.Middleware;
using HR.LeaveManagement.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigurePersistanceServices(builder.Configuration);
builder.Services.ConfigureInfrastructureServices(builder.Configuration);
builder.Services.ConfigureIdentityServices(builder.Configuration);

builder.Services.AddCors(o =>
{
    o.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});


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
app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthorization();
app.UseCors("CorsPolicy");


app.MapControllers();

app.Run();
