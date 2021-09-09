using FluentAssertions;
using TodoAPI.Todos;
using Xunit;

namespace TodoAPI.Tests
{
    public class GetTodosTests
    {
        [Fact]
        public async Task ShouldBeAbleToGetAllTodos()
        {
            var repository = new TodoRepository();
            var createHandler = new CreateTodo(repository);

            TodoUtilities.CreateDummyTodo(createHandler);
            TodoUtilities.CreateDummyTodo(createHandler);

            var getAllHandler = new GetTodos(repository);
            var todos = getAllHandler.Handle();

            todos.Count.Should().Be(2);
        }
    }
}
