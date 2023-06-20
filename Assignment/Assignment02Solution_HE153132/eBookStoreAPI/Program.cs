using Autofac.Core;
using BusinessObject.DBContext;
using DataAccess.DAO;
using DataAccess.IDAO;
using DataAccess.IRepository;
using DataAccess.Repository;
using eBookStoreAPI.Services;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContextPool<ApplicationDBContext>(options =>
//{
//    options.UseSqlServer(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("connection"));

//    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
//});

var connectionString = builder.Configuration.GetConnectionString("connection");
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(connectionString);
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddControllers().AddOData(option => option.Select().Filter().Count().OrderBy().Expand().SetMaxTop(100));

builder.Services.AddScoped<IAuthorDAO, AuthorDAO>();
builder.Services.AddScoped<IBookDAO, BookDAO>();
builder.Services.AddScoped<IBookAuthorDAO, BookAuthorDAO>();
builder.Services.AddScoped<IPublisherDAO, PublisherDAO>();
builder.Services.AddScoped<IRoleDAO, RoleDAO>();
builder.Services.AddScoped<IUserDAO, UserDAO>();


builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookAuthorRepository, BookAuthorRepository>();
builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();



builder.Services.AddAutoMapper(typeof(AuthorMapper));
//builder.Services.AddAutoMapper(typeof());

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
