using MultiTenantBlog.API.Abstractions.Repo;
using MultiTenantBlog.API.Abstractions.Service;
using MultiTenantBlog.API.ConfClasses;
using MultiTenantBlog.API.Registration;
using MultiTenantBlog.API.Repositories;
using MultiTenantBlog.API.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//external configuration file for tenant settings
builder.Services.Configure<TentantSettings>(builder.Configuration.GetSection("TentantSettings"));
builder.Configuration.AddJsonFile("TentantSettings.json", optional: false, reloadOnChange: true);

//builder.Services.AddDbContext<MultiTenantBlogCtx>(option => option.UseSqlServer(e => e.MigrationsAssembly(typeof(MultiTenantBlogCtx).Assembly.FullName)));

builder.Services.AddTransient<ITentantService, TentantService>();

//builder.Services.AddMediatR(typeof(Startup));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IReadRepo, ReadRepo>();
builder.Services.AddScoped<IWriteRepo, WriteRepo>();

await builder.Services.AddPersistenceService();

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
