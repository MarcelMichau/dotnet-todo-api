using FluentAssertions;
using TodoAPI.Todos.Commands;
using TodoAPI.Todos.Queries;
using Xunit;
using static TodoAPI.Todos.Commands.CreateTodoCommand;
using static TodoAPI.Todos.Commands.EditTodoCommand;
using static TodoAPI.Todos.Queries.GetTodoQuery;

namespace TodoAPI.Tests
{
    public class EditTodoCommandTests
    {
        [Fact]
        public async Task ShouldBeAbleToEditTodo()
        {
            var repository = new TodoRepository();
            var createHandler = new CreateTodoCommandHandler(repository);

            var id = await TodoUtilities.CreateDummyTodo(createHandler);

            var completedTodo = new Todo
            {
                IsCompleted = true
            };

            var editHandler = new EditTodoCommandHandler(repository);
            await editHandler.Handle(new EditTodoCommand(id, completedTodo), CancellationToken.None);

            var getHandler = new GetTodoQueryHandler(repository);

            var editedTodo = await getHandler.Handle(new GetTodoQuery(id), CancellationToken.None);

            editedTodo.IsCompleted.Should().BeTrue();
        }
    }
}
