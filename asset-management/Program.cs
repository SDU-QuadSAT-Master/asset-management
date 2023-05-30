
using asset_management;
using Microsoft.AspNetCore.Builder;
using System.Text.Json.Serialization;
var policy = "AllowSpecificOrigin";


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddHostedService(provider => new RabbitWorker(new[] { "flights", "drones" }));
builder.Services.AddScoped<IDroneService, DroneService>();
builder.Services.AddScoped<IFlightEntryService, FlightEntryService>();
builder.Services.AddScoped<IAntennaService, AntennaService>();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policy,
        builder => builder
            .WithOrigins("https://frontend.benjaminklerens.com")
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(policy);
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers().
    RequireCors(policy);
});
app.Run();
