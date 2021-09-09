using FluentAssertions;
using TodoAPI.Todos;
using Xunit;

namespace TodoAPI.Tests
{
    public class DeleteTodoTests
    {
        [Fact]
        public async Task ShouldBeAbleToDeleteTodo()
        {
            var repository = new TodoRepository();
            var createHandler = new CreateTodo(repository);

            var id = TodoUtilities.CreateDummyTodo(createHandler);

            var deleteHandler = new DeleteTodo(repository);
            deleteHandler.Handle(id);

            var getAllHandler = new GetTodos(repository);
            var todos = getAllHandler.Handle();

            todos.Count.Should().Be(0);
        }
    }
}
