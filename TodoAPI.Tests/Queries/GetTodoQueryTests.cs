using FluentAssertions;
using TodoAPI.Todos.Queries;
using Xunit;
using static TodoAPI.Todos.Commands.CreateTodoCommand;
using static TodoAPI.Todos.Queries.GetTodoQuery;

namespace TodoAPI.Tests
{
    public class GetTodoQueryTests
    {
        [Fact]
        public async Task ShouldBeAbleToGetTodo()
        {
            var repository = new TodoRepository();
            var createHandler = new CreateTodoCommandHandler(repository);

            var id = await TodoUtilities.CreateDummyTodo(createHandler);

            var getHandler = new GetTodoQueryHandler(repository);
            var todo = await getHandler.Handle(new GetTodoQuery(id), CancellationToken.None);

            todo.Text.Should().Be("Write another Test");
            todo.IsCompleted.Should().BeFalse();
        }
    }
}
