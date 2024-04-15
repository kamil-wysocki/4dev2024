using _4dev2024.Initializer;
using _4dev2024.Shared.Infrastructure.Modules;

var builder = WebApplication.CreateBuilder(args)
                            .ConfigureModules();

builder.Services.RegisterModules(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseModules();

app.Run();
