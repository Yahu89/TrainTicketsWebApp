using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using TrainTicketsWebApp.CQRS.Queries.Station;
using TrainTicketsWebApp.Database.Configuration;
using TrainTicketsWebApp.Models;
using TrainTicketsWebApp.Models.Validation;
using TrainTicketsWebApp.Repositories.Interface;
using TrainTicketsWebApp.Repositories.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TrainTicketsDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(TrainTicketsDbContext))));
var mongoSettings = builder.Configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();

builder.Services.AddSingleton<IMongoClient>(sp => new MongoClient(mongoSettings.ConnectionString));
builder.Services.AddSingleton(sp => sp.GetRequiredService<IMongoClient>().GetDatabase(mongoSettings.DatabaseName));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ITrainStationRepository, TrainStationRepository>();
builder.Services.AddScoped<ITrainTypeRepository, TrainTypeRepository>();
builder.Services.AddScoped<IRouteRepository, RouteRepository>();
builder.Services.AddScoped<IRouteDetailsRepository, RouteDetailsRepository>();
builder.Services.AddScoped<ITripRepository, TripRepository>();
builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
builder.Services.AddSingleton<ITripOccupationRepository, TripOccupationRepository>();
builder.Services.AddScoped<ITourRepository, TourRepository>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddValidatorsFromAssemblyContaining<CreateTrainStationCommandValidator>()
							.AddFluentValidationAutoValidation()
							.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CreateTrainTypeCommandValidator>()
							.AddFluentValidationAutoValidation()
							.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CreateRouteCommandValidator>()
							.AddFluentValidationAutoValidation()
							.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<ReservationValidator>()
							.AddFluentValidationAutoValidation()
							.AddFluentValidationClientsideAdapters();

builder.Services.AddMediatR(typeof(GetAllStationsQuery));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<TrainTicketsDbContext>();
var dbIntializer = new Seeder(dbContext);

await dbIntializer.SeedData();

app.Run();
