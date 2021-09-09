using FluentAssertions;
using TodoAPI.Todos;
using Xunit;

namespace TodoAPI.Tests
{
    public class GetTodoTests
    {
        [Fact]
        public async Task ShouldBeAbleToGetTodo()
        {
            var repository = new TodoRepository();
            var createHandler = new CreateTodo(repository);

            var id = TodoUtilities.CreateDummyTodo(createHandler);

            var getHandler = new GetTodo(repository);
            var todo = getHandler.Handle(id);

            todo.Text.Should().Be("Write another Test");
            todo.IsCompleted.Should().BeFalse();
        }
    }
}
