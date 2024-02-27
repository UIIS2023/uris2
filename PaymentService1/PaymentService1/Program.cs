using Microsoft.AspNetCore.Hosting;

namespace PaymentService1
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








/*using PaymentService1.Data;
using AutoMapper;
using System;
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
    setupAction.SwaggerDoc("PaymentOpenApiSpecification", new Microsoft.OpenApi.Models.OpenApiInfo()
    {
        Title = "Payment API",
        Version = "1",
        Description = "Pomocu ovog API-ja moze da se vrsi pregled, dodavanje, modifikovanje i brisanje uplate i kursa.",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Aleksandra Vujovic",
            Email = "avujovic737@gmail.com",
            Url = new Uri("http://www.ftn.uns.ac.rs/")
        },
        License = new Microsoft.OpenApi.Models.OpenApiLicense
        {
            Name = "FTN licence",
            Url = new Uri("http://www.ftn.uns.ac.rs/")
        },
        TermsOfService = new Uri("http://www.ftn.uns.ac.rs/paymentService1TermsOfService")

    });
    var xmlComments = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //pravimo putanju do xml fajla sa komentarima
    var xmlCommentsPath = Path.Combine(AppContext.BaseDirectory, xmlComments);
    //govorimo swaggeru gde se nalazi dati xml fajl sa komentarima
    setupAction.IncludeXmlComments(xmlCommentsPath);
});
builder.Services.AddScoped<IUplataRepository, UplataRepository>();
builder.Services.AddScoped<IKursnaListaRepository, KursnaListaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(setupAction =>
    {
        setupAction.SwaggerEndpoint("/swagger/PaymentOpenApiSpecification/swagger.json", "Payment API");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
*/



