using EB.Application;
using EB.Infrastructure;
using EB.Presentation.Shared.Filters;
using EB.Presentation.Shared.Handlers;
using EB.Presentation.Shared.Middlewares;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//>>> Create Logs folder for Serilog
var logPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Logs");
if (!Directory.Exists(logPath))
{
    Directory.CreateDirectory(logPath);
}

//>>> Create Docs folder for DocumentManager
var docPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Docs");
if (!Directory.Exists(docPath))
{
    Directory.CreateDirectory(docPath);
}

//>>> Create Imgs folder for ImageManager
var imgPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Imgs");
if (!Directory.Exists(imgPath))
{
    Directory.CreateDirectory(imgPath);
}


builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddExceptionHandler<CustomExceptionHandler>();
builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(builder => builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});
builder.Services.AddControllers();
    //.AddOData(opt => opt
    //    .Count()
    //    .Filter()
    //    .Expand()
    //    .Select()
    //    .OrderBy()
    //    .SetMaxTop(null));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Easy Billing API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                new string[] { }
            }
        });

    c.OperationFilter<SwaggerOperationFilter>();
});
builder.Services.Configure<ApiBehaviorOptions>(x =>
{
    x.SuppressModelStateInvalidFilter = true;
});
//builder.Services.RegisterSystemSeedManager(builder.Configuration);
//builder.Services.RegisterDemoSeedManager(builder.Configuration);
var app = builder.Build();
//craete database
//app.CreateDatabase();

//seed database with system data
//app.SeedSystemData();

//seed database with demo data
if (app.Configuration.GetValue<bool>("IsDemoVersion"))
{
    //app.SeedDemoData();
}

app.UseExceptionHandler(options => { });

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors();

app.UseMiddleware<GlobalExceptionHandler>();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Configuration.GetValue<bool>("EnableSwaggerInProduction"))
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Easy Billing V1");
    });

}

app.UseHttpsRedirection();

app.Run();
