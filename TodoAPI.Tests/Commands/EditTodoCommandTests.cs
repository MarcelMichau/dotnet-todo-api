using FluentAssertions;
using TodoAPI.Todos.Commands;
using TodoAPI.Todos.Queries;
using Xunit;

namespace TodoAPI.Tests
{
    public class EditTodoCommandTests
    {
        [Fact]
        public async Task ShouldBeAbleToEditTodo()
        {
            var repository = new TodoRepository();
            var createHandler = new CreateTodoCommand(repository);

            var id = TodoUtilities.CreateDummyTodo(createHandler);

            var completedTodo = new Todo
            {
                IsCompleted = true
            };

            var editHandler = new EditTodoCommand(repository);
            editHandler.Handle(id, completedTodo);

            var getHandler = new GetTodoQuery(repository);

            var editedTodo = getHandler.Handle(id);

            editedTodo.IsCompleted.Should().BeTrue();
        }
    }
}
