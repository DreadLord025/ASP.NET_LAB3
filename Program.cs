using System;
using System.IO;
using System.Text.Json;
using System.Xml;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration.Ini;
using Comp; 
using Me;
using lab3.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<CalcService>();
builder.Services.AddControllers();
builder.Services.AddTransient<TimeOfDayService>();
var app = builder.Build();
app.MapControllers();


string pathJson = "Microsoft.json";
string pathXML = "Google.xml";
string pathIni = "Apple.ini";
string pathMe = "Me.json";

MySelf mySelf = MySelf.meFromJson(pathMe);

Company Microsoft = Company.compFromJson(pathJson);
Company Google = Company.compFromXML(pathXML);
Company Apple = Company.compFromIni(pathIni);

app.MapGet("/info", () => Apple.Info()); 
app.MapGet("/", () => Google.RandNum()); 
app.MapGet("/max", () => workersMax(new Company[] { Microsoft, Google, Apple }).name);
app.MapGet("/me", () => mySelf.MyInfo());

app.Run();

Company workersMax(Company[] companies)
{
    int maxWorkers = 0;
    Company companyWithMaxWorkers = null;

    foreach (Company company in companies)
    {
        if (company.workers > maxWorkers)
        {
            maxWorkers = company.workers;
            companyWithMaxWorkers = company;
        }
    }

    return companyWithMaxWorkers;
}
