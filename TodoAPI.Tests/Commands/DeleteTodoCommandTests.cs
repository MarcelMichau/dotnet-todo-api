using FluentAssertions;
using TodoAPI.Todos.Commands;
using TodoAPI.Todos.Queries;
using Xunit;

namespace TodoAPI.Tests
{
    public class DeleteTodoCommandTests
    {
        [Fact]
        public async Task ShouldBeAbleToDeleteTodo()
        {
            var repository = new TodoRepository();
            var createHandler = new CreateTodoCommand(repository);

            var id = TodoUtilities.CreateDummyTodo(createHandler);

            var deleteHandler = new DeleteTodoCommand(repository);
            deleteHandler.Handle(id);

            var getAllHandler = new GetTodosQuery(repository);
            var todos = getAllHandler.Handle();

            todos.Count.Should().Be(0);
        }
    }
}
