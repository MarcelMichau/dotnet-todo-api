using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.Controllers;
using TodoAPI.Todos;
using Xunit;

namespace TodoAPI.Tests;
public class TodoTests
{
    [Fact]
    public async Task ShouldBeAbleToCreateTodo()
    {
        var repository = new TodoRepository();
        var handler = new CreateTodo(repository);

        var todo = new Todo
        {
            Text = "Write a Test"
        };

        var newTodo = handler.Handle(todo);

        newTodo.Text.Should().BeEquivalentTo(todo.Text);
    }

    [Fact]
    public async Task ShouldBeAbleToGetTodo()
    {
        var repository = new TodoRepository();
        var createHandler = new CreateTodo(repository);

        var id = CreateDummyTodo(createHandler);

        var getHandler = new GetTodo(repository);
        var todo = getHandler.Handle(id);

        todo.Text.Should().Be("Write another Test");
        todo.IsCompleted.Should().BeFalse();
    }

    [Fact]
    public async Task ShouldBeAbleToGetAllTodos()
    {
        var repository = new TodoRepository();
        var createHandler = new CreateTodo(repository);

        CreateDummyTodo(createHandler);
        CreateDummyTodo(createHandler);

        var getAllHandler = new GetTodos(repository);
        var todos = getAllHandler.Handle();

        todos.Count.Should().Be(2);
    }

    [Fact]
    public async Task ShouldBeAbleToEditTodo()
    {
        var repository = new TodoRepository();
        var createHandler = new CreateTodo(repository);

        var id = CreateDummyTodo(createHandler);

        var completedTodo = new Todo
        {
            IsCompleted = true
        };

        var editHandler = new EditTodo(repository);
        editHandler.Handle(id, completedTodo);

        var getHandler = new GetTodo(repository);

        var editedTodo = getHandler.Handle(id);

        editedTodo.IsCompleted.Should().BeTrue();
    }

    [Fact]
    public async Task ShouldBeAbleToDeleteTodo()
    {
        var repository = new TodoRepository();
        var createHandler = new CreateTodo(repository);

        var id = CreateDummyTodo(createHandler);

        var deleteHandler = new DeleteTodo(repository);
        deleteHandler.Handle(id);

        var getAllHandler = new GetTodos(repository);
        var todos = getAllHandler.Handle();

        todos.Count.Should().Be(0);
    }

    private static int CreateDummyTodo(CreateTodo handler)
    {
        var todo = new Todo
        {
            Text = "Write another Test"
        };

        var newTodo = handler.Handle(todo);

        return newTodo.Id;
    }
}