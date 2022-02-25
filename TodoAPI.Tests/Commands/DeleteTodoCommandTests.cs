using FluentAssertions;
using TodoAPI.Todos.Commands;
using TodoAPI.Todos.Queries;
using Xunit;
using static TodoAPI.Todos.Commands.CreateTodoCommand;
using static TodoAPI.Todos.Commands.DeleteTodoCommand;
using static TodoAPI.Todos.Queries.GetTodosQuery;

namespace TodoAPI.Tests.Commands;

public class DeleteTodoCommandTests
{
    [Fact]
    public async Task ShouldBeAbleToDeleteTodo()
    {
        var repository = new TodoRepository();
        var createHandler = new CreateTodoCommandHandler(repository);

        var id = await TodoUtilities.CreateDummyTodo(createHandler);

        var deleteHandler = new DeleteTodoCommandHandler(repository);
        await deleteHandler.Handle(new DeleteTodoCommand(id), CancellationToken.None);

        var getAllHandler = new GetTodosQueryHandler(repository);
        var todos = await getAllHandler.Handle(new GetTodosQuery(), CancellationToken.None);

        todos.Count.Should().Be(0);
    }
}