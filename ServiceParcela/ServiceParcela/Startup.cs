using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.OpenApi.Models;
using ServiceParcela.Entities;
using ServiceParcela.Repositories;
using ServiceParcela.ServiceCalls;
using ServiceParcela.Services;
using System.Reflection;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using ServiceParcela.Helper;

namespace ServiceParcela
{
    /// <summary>
    /// Startup
    /// </summary>
    ///
    public class Startup
    {
        /// <summary>
        /// Configuration
        /// </summary>
        ///
        public IConfiguration Configuration { get; }
        /// <summary>
        /// Startup
        /// </summary>
        ///
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        /// <summary>
        /// ConfigureServices
        /// </summary>
        ///
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers(setup =>
            {
                setup.ReturnHttpNotAcceptable = true; //svaki put kad stigne nesto sto nije eksplicitno podrzano vrati odgovarajuci status i stavi do znanja klijentu da to nije podrzano 
            }).AddXmlDataContractSerializerFormatters()//ovim je podrzan i xml
                                                       //svaki put kad vidis interfejs da se trazi prosledi konkretnu implementaciju tog interfejsa koja je proslednjena
                                                       //napravi mi instancu toga sto zelis svaki put kada dodje novi request. svaki put kad stigne novi request od kljenta napravice se nova instanca toga necega
                .ConfigureApiBehaviorOptions(setupAction => //Deo koji se odnosi na podrzavanje Problem Details for HTTP APIs
                {
                    setupAction.InvalidModelStateResponseFactory = context =>
                    {
                        //Kreiramo problem details objekat
                        ProblemDetailsFactory problemDetailsFactory = context.HttpContext.RequestServices
                            .GetRequiredService<ProblemDetailsFactory>();

                        //Prosledjujemo trenutni kontekst i ModelState, ovo prevodi validacione greske iz ModelState-a u RFC format
                        ValidationProblemDetails problemDetails = problemDetailsFactory.CreateValidationProblemDetails(
                            context.HttpContext,
                            context.ModelState);

                        //Ubacujemo dodatne podatke
                        problemDetails.Detail = "Pogledajte polje errors za detalje.";
                        problemDetails.Instance = context.HttpContext.Request.Path;

                        //po defaultu se sve vraca kao status 400 BadRequest, to je ok kada nisu u pitanju validacione greske,
                        //ako jesu hocemo da koristimo status 422 UnprocessibleEntity
                        //trazimo info koji status kod da koristimo
                        var actionExecutiongContext = context as ActionExecutingContext;

                        //proveravamo da li postoji neka greska u ModelState-u, a takodje proveravamo da li su svi prosledjeni parametri dobro parsirani
                        //ako je sve ok parsirano ali postoje greske u validaciji hocemo da vratimo status 422
                        if ((context.ModelState.ErrorCount > 0) &&
                            (actionExecutiongContext?.ActionArguments.Count == context.ActionDescriptor.Parameters.Count))
                        {
                            problemDetails.Type = "https://google.com"; //inace treba da stoji link ka stranici sa detaljima greske
                            problemDetails.Status = StatusCodes.Status422UnprocessableEntity;
                            problemDetails.Title = "Doslo je do greske prilikom validacije.";

                            //sve vracamo kao UnprocessibleEntity objekat
                            return new UnprocessableEntityObjectResult(problemDetails)
                            {
                                ContentTypes = { "application/problem+json" }
                            };
                        };

                        //ukoliko postoji nesto što nije moglo da se parsira hocemo da vracamo status 400 kao i do sada
                        problemDetails.Status = StatusCodes.Status400BadRequest;
                        problemDetails.Title = "Doslo je do greske prilikom parsiranja poslatog sadrzaja.";
                        return new BadRequestObjectResult(problemDetails)
                        {
                            ContentTypes = { "application/problem+json" }
                        };
                    };
                });
            services.AddScoped<IDeoParceleRepository, DeoParceleService>();
            services.AddScoped<IKatastarskaOpstinaRepository, KatastarskaOpstinaService>();
            services.AddScoped<IKlasaRepository, KlasaService>();
            services.AddScoped<IKulturaRepository, KulturaService>();
            services.AddScoped<IOblikSvojineRepository, OblikSvojineService>();
            services.AddScoped<IObradivostRepository, ObradivostService>();
            services.AddScoped<IOdvodnjavanjeRepository, OdvodnjavanjeService>();
            services.AddScoped<IParcelaRepository, ParcelaService>();
            services.AddScoped<IZasticenaZonaRepository, ZasticenaZonaService>();
            services.AddScoped<IKupacService, KupacService>();
            services.AddScoped<IUserRepository, UserService>();
            services.AddScoped<IAuthHelper, AuthHelper>();
            services.AddScoped<ILogerService, LoggerService>();

            //konfiguracije za automaper - pogledaj ceo domen gde se izvrsava servis i trazi konfiguracije za automapper.
            //te konfiguracije su profili, za svako mapiranje ce se definisati jedan profil i reci iz tog objekta mapitaj u taj objekat na takav nacin

            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("ParcelaOpenApiSpecification",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "Parcela API",
                        Version = "1",
                        Description = "Parcela API omogucava pregled, modifikovanje i brisanje svih entiteta parcela servisa.",
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact
                        {
                            Name = "Emilija Ljubisavljevic",
                            Email = "ljubisavljevic.ema@gmail.com",
                            Url = new Uri("http://www.ftn.uns.ac.rs/")
                        },
                        License = new Microsoft.OpenApi.Models.OpenApiLicense
                        {
                            Name = "FTN licence",
                            Url = new Uri($"http://www.ftn.uns.ac.rs/")
                        },
                        TermsOfService = new Uri("http://www.ftn.uns.ac.rs/serviceParcelaTermsOfService")
                    });
                

                setupAction.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Unesite token",
                    Name = "Autorizacija korisnika",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });

                setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                    }
                });


                //Pomocu refleksije dobijamo ime XML fajla sa komentarima (ovako smo ga nazvali u Project -> Properties)
                var xmlComments = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

                //Pravimo putanju do XML fajla sa komentarima
                var xmlCommentsPath = Path.Combine(AppContext.BaseDirectory, xmlComments);

                //Govorimo swagger-u gde se nalazi dati xml fajl sa komentarima
                setupAction.IncludeXmlComments(xmlCommentsPath);
            });


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Dodajemo DbContext koji zelimo da koristimo
            services.AddDbContextPool<ParcelaContex>(options => options.UseSqlServer(Configuration.GetConnectionString("parcelaDB")));
        }
        /// <summary>
        /// Configure
        /// </summary>
        ///
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder => //u slucaju da se vrati statusni kod 500 da klijentu ispise ovakvu gresku jer je to nas problem, a ne korisnikov
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("Doslo je do neocekivane greske. Molimo pokusajte kasnije.");
                    });
                });
            }


            app.UseSwagger();
            app.UseSwaggerUI(setupAction =>
            {
                //Podesavamo endpoint gde Swagger UI moze da pronadje OpenAPI specifikaciju
                setupAction.SwaggerEndpoint("/swagger/ParcelaOpenApiSpecification/swagger.json", "Parcela API");
                // setupAction.RoutePrefix = ""; //Dokumentacija ce sada biti dostupna na root-u (ne mora da se pise /swagger)
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

