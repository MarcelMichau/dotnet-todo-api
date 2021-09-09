using FluentAssertions;
using TodoAPI.Todos.Commands;
using TodoAPI.Todos.Queries;
using Xunit;

namespace TodoAPI.Tests
{
    public class GetTodosQueryTests
    {
        [Fact]
        public async Task ShouldBeAbleToGetAllTodos()
        {
            var repository = new TodoRepository();
            var createHandler = new CreateTodoCommand(repository);

            TodoUtilities.CreateDummyTodo(createHandler);
            TodoUtilities.CreateDummyTodo(createHandler);

            var getAllHandler = new GetTodosQuery(repository);
            var todos = getAllHandler.Handle();

            todos.Count.Should().Be(2);
        }
    }
}
