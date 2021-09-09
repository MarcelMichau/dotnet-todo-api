using FluentAssertions;
using TodoAPI.Todos.Commands;
using TodoAPI.Todos.Queries;
using Xunit;

namespace TodoAPI.Tests
{
    public class GetTodoQueryTests
    {
        [Fact]
        public async Task ShouldBeAbleToGetTodo()
        {
            var repository = new TodoRepository();
            var createHandler = new CreateTodoCommand(repository);

            var id = TodoUtilities.CreateDummyTodo(createHandler);

            var getHandler = new GetTodoQuery(repository);
            var todo = getHandler.Handle(id);

            todo.Text.Should().Be("Write another Test");
            todo.IsCompleted.Should().BeFalse();
        }
    }
}
