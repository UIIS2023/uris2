using KomisijaService.Entities;
using KomisijaService.Repository;
using KomisijaService.ServiceCalls;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using KomisijaService.Helper;
using KomisijaService.Services;
using KomisijaService.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace KomisijaService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers(setup =>
            {
                setup.ReturnHttpNotAcceptable = true; //svaki put kad stigne nesto sto nije eksplicitno podrzano vrati odgovarajuci status i stavi do ynanja klijentu da to nije podrzano 
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
                        }

                        //ukoliko postoji nesto što nije moglo da se parsira hocemo da vracamo status 400 kao i do sada
                        problemDetails.Status = StatusCodes.Status400BadRequest;
                        problemDetails.Title = "Doslo je do greske prilikom parsiranja poslatog sadrzaja.";
                        return new BadRequestObjectResult(problemDetails)
                        {
                            ContentTypes = { "application/problem+json" }
                        };
                    };
                });
            services.AddScoped<IKomisijaRepository, KomisijaSService>();
            services.AddScoped<IPredsednikRepository, PredsednikService>();
            services.AddScoped<IClanoviRepository, ClanoviService>();
            services.AddScoped<IUserRepository, UserService>();
            services.AddScoped<ILoggerService, LoggerService>();
            services.AddScoped<ILicnostService, LicnostService>();
            services.AddScoped<IAuthHelper, AuthHelper>();


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
#pragma warning disable CS8604 // Possible null reference argument.
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
#pragma warning restore CS8604 // Possible null reference argument.
            });
            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("KomisijaServiceOpenApiSpecification",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "Komisija Service API",
                        Version = "1",
                        Description = "Ovaj API sluzi za rad sa objektima tipa Komisija.",

                    });
                setupAction.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme {
                        Reference = new OpenApiReference {
                            Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
                });
                var xmlComments = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";           
            });
            services.AddDbContext<KomisijaContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
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
                setupAction.SwaggerEndpoint("/swagger/KomisijaServiceOpenApiSpecification/swagger.json", "Komisija Service API");
                setupAction.RoutePrefix = "";
            });
            app.UseAuthentication();
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

