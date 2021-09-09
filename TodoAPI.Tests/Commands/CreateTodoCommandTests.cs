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

            var todo = new Todo
            {
                Text = "Write a Test"
            };

            var newTodo = await handler.Handle(new Todos.Commands.CreateTodoCommand(todo), CancellationToken.None);

            newTodo.Text.Should().BeEquivalentTo(todo.Text);
        }
    }
}
