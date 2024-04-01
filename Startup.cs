using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Runtime;
using serverless_dotnet.Helper;
using Tooth_Booth_API.BusinessLogic.Interface;
using Tooth_Booth_API.BusinessLogic;
using Tooth_Booth_API.Models;
using Tooth_Booth_API.Repository;
using serverless_dotnet.Models;

namespace serverless_dotnet;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
        var credentials = new BasicAWSCredentials("AccessKey", "SecretKey");
        var config = new AmazonDynamoDBConfig()
        {
            RegionEndpoint = RegionEndpoint.EUNorth1
        };

        var client = new AmazonDynamoDBClient(credentials, config);
        services.AddSingleton<IAmazonDynamoDB>(client);
        services.AddSingleton<IDynamoDBContext, DynamoDBContext>();
        services.AddScoped<IClinicsBusiness, ClinicsBusinesscs>();
        services.AddScoped<IRepository<Clinic, int>, ClinicRepository>();
        services.AddScoped<IDentistBusiness, DentistBusiness>();
        services.AddScoped<IRepository<Dentist, string>, DentistRepository>();

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
            });
        });
    }
}