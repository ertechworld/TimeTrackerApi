using Microsoft.EntityFrameworkCore;
using TimeTracker.Service.Data;
using TimeTracker.Service.DTOMapper;
using TimeTracker.Service.Services;
using TimeTracker.Service.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    { options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)); 
});

builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IStatusService, StatusService>();
builder.Services.AddScoped<IUserattendanceService, UserattendanceService>();
builder.Services.AddScoped<IJobtypeService, JobTypeService>();
builder.Services.AddScoped<ILeavetypeService, LeavetypeService>();
builder.Services.AddScoped<ILeaveService, LeaveService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
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
