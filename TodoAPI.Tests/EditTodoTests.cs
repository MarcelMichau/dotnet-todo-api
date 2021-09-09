using FluentAssertions;
using TodoAPI.Todos;
using Xunit;

namespace TodoAPI.Tests
{
    public class EditTodoTests
    {
        [Fact]
        public async Task ShouldBeAbleToEditTodo()
        {
            var repository = new TodoRepository();
            var createHandler = new CreateTodo(repository);

            var id = TodoUtilities.CreateDummyTodo(createHandler);

            var completedTodo = new Todo
            {
                IsCompleted = true
            };

            var editHandler = new EditTodo(repository);
            editHandler.Handle(id, completedTodo);

            var getHandler = new GetTodo(repository);

            var editedTodo = getHandler.Handle(id);

            editedTodo.IsCompleted.Should().BeTrue();
        }
    }
}
