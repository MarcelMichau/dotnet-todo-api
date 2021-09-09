using TodoAPI;
using TodoAPI.Todos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "TodoAPI", Version = "v1" });
});

builder.Services.AddSingleton<TodoRepository>();

builder.Services.AddScoped<CreateTodo>();
builder.Services.AddScoped<DeleteTodo>();
builder.Services.AddScoped<EditTodo>();
builder.Services.AddScoped<GetTodo>();
builder.Services.AddScoped<GetTodos>();

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
