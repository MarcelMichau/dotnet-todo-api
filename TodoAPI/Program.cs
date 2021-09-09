using TodoAPI;
using TodoAPI.Todos.Commands;
using TodoAPI.Todos.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "TodoAPI", Version = "v1" });
});

builder.Services.AddSingleton<TodoRepository>();

builder.Services.AddScoped<CreateTodoCommand>();
builder.Services.AddScoped<DeleteTodoCommand>();
builder.Services.AddScoped<EditTodoCommand>();
builder.Services.AddScoped<GetTodoQuery>();
builder.Services.AddScoped<GetTodosQuery>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoAPI v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
