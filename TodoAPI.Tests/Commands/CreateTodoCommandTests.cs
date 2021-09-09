using FluentAssertions;
using Xunit;
using static TodoAPI.Todos.Commands.CreateTodoCommand;

namespace TodoAPI.Tests
{
    public class CreateTodoCommandTests
    {
        [Fact]
        public async Task ShouldBeAbleToCreateTodo()
        {
            var repository = new TodoRepository();
            var handler = new CreateTodoCommandHandler(repository);

            var todoText = "Write a Test";

            var newTodo = await handler.Handle(new Todos.Commands.CreateTodoCommand(todoText), CancellationToken.None);

            newTodo.Text.Should().BeEquivalentTo(todoText);
        }
    }
}
