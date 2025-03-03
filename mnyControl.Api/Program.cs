using Microsoft.EntityFrameworkCore;
using mnyControl.Api.Data;
using mnyControl.Api.Endpoints;
using mnyControl.Api.Handlers;
using mnyControl.Core.Handlers;
using mnyControl.Core.Models;
using mnyControl.Core.Requests.Categories;
using mnyControl.Core.Responses;

var builder = WebApplication.CreateBuilder(args);

var cnnStr = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => x.CustomSchemaIds(n => n.FullName));
builder.Services.AddDbContext<AppDbContext>(x => { x.UseSqlServer(cnnStr); });

builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => new { message = "ok"});
app.MapEndpoints();

app.Run();
