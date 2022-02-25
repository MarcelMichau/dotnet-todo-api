using FluentAssertions;
using TodoAPI.Todos.Queries;
using Xunit;
using static TodoAPI.Todos.Commands.CreateTodoCommand;
using static TodoAPI.Todos.Queries.GetTodosQuery;

namespace TodoAPI.Tests.Queries;

public class GetTodosQueryTests
{
    [Fact]
    public async Task ShouldBeAbleToGetAllTodos()
    {
        var repository = new TodoRepository();
        var createHandler = new CreateTodoCommandHandler(repository);

        await TodoUtilities.CreateDummyTodo(createHandler);
        await TodoUtilities.CreateDummyTodo(createHandler);

        var getAllHandler = new GetTodosQueryHandler(repository);
        var todos = await getAllHandler.Handle(new GetTodosQuery(), CancellationToken.None);

        todos.Count.Should().Be(2);
    }
}