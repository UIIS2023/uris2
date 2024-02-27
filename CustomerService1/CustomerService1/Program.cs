using Microsoft.AspNetCore.Hosting;

namespace CustomerService1
{
    public class Program
    {

        protected Program()
        {

        }

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
              Host.CreateDefaultBuilder(args)
                  .ConfigureWebHostDefaults(webBuilder =>
                  {
                      webBuilder.UseStartup<Startup>();
                  });
    }
}











/*using CustomerService1.Data;
using AutoMapper;
using System;
using CustomerService1.ServiceCalls;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(setup =>
{
    setup.ReturnHttpNotAcceptable = true;
}).AddXmlDataContractSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.SwaggerDoc("CustomerOpenApiSpecification", new Microsoft.OpenApi.Models.OpenApiInfo()
    {
        Title= "Customer API",
        Version= "1",
        Description= "Pomocu ovog API-ja moze da se vrsi pregled, dodavanje, modifikovanje i brisanje kontakt osobe, kupca i prioriteta.",
        Contact= new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name= "Aleksandra Vujovic",
            Email= "avujovic737@gmail.com",
            Url= new Uri("http://www.ftn.uns.ac.rs/")
        },
        License= new Microsoft.OpenApi.Models.OpenApiLicense
        {
            Name= "FTN licence",
            Url= new Uri("http://www.ftn.uns.ac.rs/")
        },
        TermsOfService= new Uri("http://www.ftn.uns.ac.rs/customerService1TermsOfService")

    });
    var xmlComments = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //pravimo putanju do xml fajla sa komentarima
    var xmlCommentsPath = Path.Combine(AppContext.BaseDirectory, xmlComments);
    //govorimo swaggeru gde se nalazi dati xml fajl sa komentarima
    setupAction.IncludeXmlComments(xmlCommentsPath);
});
builder.Services.AddScoped<IKontaktOsobaRepository, KontaktOsobaRepository>();
builder.Services.AddScoped<IPrioritetRepository, PrioritetRepository>();
builder.Services.AddScoped<IKupacRepository, KupacRepository>();
builder.Services.AddScoped<IAdresaService, AdresaService>();
builder.Services.AddScoped<IOvlascenoLiceService, OvlascenoLiceService>();
builder.Services.AddScoped<IJavnoNadmetanjeService, JavnoNadmetanjeService>();
builder.Services.AddScoped<IUplataService, UplataService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(setupAction =>
    {
        setupAction.SwaggerEndpoint("/swagger/CustomerOpenApiSpecification/swagger.json", "Customer API");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
*/


