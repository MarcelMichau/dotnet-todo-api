using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.Controllers;
using Xunit;

namespace TodoAPI.Tests;
public class TodoTests
{
    [Fact]
    public async Task ShouldBeAbleToCreateTodo()
    {
        var repository = new TodoRepository();
        var controller = new TodosController(repository);

        var todo = new Todo
        {
            Text = "Write a Test"
        };

        var response = await controller.CreateTodo(todo);
        var result = response as CreatedAtRouteResult;
        var newTodo = result.Value as Todo;

        newTodo.Text.Should().BeEquivalentTo(todo.Text);
    }

    [Fact]
    public async Task ShouldBeAbleToGetTodo()
    {
        var repository = new TodoRepository();
        var controller = new TodosController(repository);

        var id = await CreateDummyTodo(controller);

        var response = await controller.GetTodo(id);
        var result = response as OkObjectResult;
        var todo = result.Value as Todo;

        todo.Text.Should().Be("Write another Test");
        todo.IsCompleted.Should().BeFalse();
    }

    [Fact]
    public async Task ShouldBeAbleToGetAllTodos()
    {
        var repository = new TodoRepository();
        var controller = new TodosController(repository);

        await CreateDummyTodo(controller);
        await CreateDummyTodo(controller);

        var response = await controller.GetTodos();
        var result = response as OkObjectResult;
        var todos = result.Value as List<Todo>;

        todos.Count.Should().Be(2);
    }

    [Fact]
    public async Task ShouldBeAbleToEditTodo()
    {
        var repository = new TodoRepository();
        var controller = new TodosController(repository);

        var id = await CreateDummyTodo(controller);

        var completedTodo = new Todo
        {
            IsCompleted = true
        };

        await controller.EditTodo(id, completedTodo);

        var response = await controller.GetTodo(id);
        var result = response as OkObjectResult;
        var editedTodo = result.Value as Todo;

        editedTodo.IsCompleted.Should().BeTrue();
    }

    [Fact]
    public async Task ShouldBeAbleToDeleteTodo()
    {
        var repository = new TodoRepository();
        var controller = new TodosController(repository);

        var id = await CreateDummyTodo(controller);

        await controller.DeleteTodo(id);

        var response = await controller.GetTodos();
        var result = response as OkObjectResult;
        var todos = result.Value as List<Todo>;

        todos.Count.Should().Be(0);
    }

    private async Task<int> CreateDummyTodo(TodosController controller)
    {
        var todo = new Todo
        {
            Text = "Write another Test"
        };

        var response = await controller.CreateTodo(todo);

        var result = response as CreatedAtRouteResult;
        var newTodo = result.Value as Todo;

        return newTodo.Id;
    }
}