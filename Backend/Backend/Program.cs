using Services.ToDoServices;

using Application.Feactures.ToDos.Queries.GetAllToDosQuery;
using Application.Feactures.ToDos.Commands.CreateToDoCommand;
using Application.Feactures.ToDos.Commands.DeleteToDoCommand;
using FluentValidation;
using Backend.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IToDoService, ToDoService>();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(
        typeof(GetAllToDoHandler).Assembly,
        typeof(CreateToDoCommand).Assembly,
        typeof(DeleteToDoCommand).Assembly
    );
});
builder.Services.AddTransient<IValidator<CreateToDoCommand>, CreateToDoValidation>();
builder.Services.AddTransient<IValidator<DeleteToDoCommand>, DeleteToDoValidation>();



builder.Services.AddCors(options => {
    options.AddPolicy("ReactApp", policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:5173");
        policyBuilder.AllowAnyHeader();
        policyBuilder.AllowAnyMethod();
        policyBuilder.AllowCredentials();
    });
});

builder.Services.AddSignalR();

var app = builder.Build();

app.MapHub<ToDoHub>("/ToDoHub");


//middleware who print information in the console about used endpoint
app.Use(async (context, next) =>
{
    Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");

    await next();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("ReactApp");
app.MapControllers();

app.Run();
