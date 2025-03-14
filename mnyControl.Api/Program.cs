using mnyControl.Api.Common.Api;
using mnyControl.Api.Endpoints;


var builder = WebApplication.CreateBuilder(args);
builder.AddConfiguration();
builder.AddSecurity();
builder.AddDataContexts();
builder.AddCrossOrigin();
builder.AddDocumentation();
builder.AddServices();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.ConfigureDevEnvironment();
}

app.UseCors();

app.UseSecurity();

app.MapEndpoints();


app.Run();
