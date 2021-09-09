using FluentAssertions;
using TodoAPI.Todos.Commands;
using Xunit;

namespace TodoAPI.Tests
{
    public class CreateTodoCommandTests
    {
        [Fact]
        public async Task ShouldBeAbleToCreateTodo()
        {
            var repository = new TodoRepository();
            var handler = new CreateTodoCommand(repository);

            var todo = new Todo
            {
                Text = "Write a Test"
            };

            var newTodo = handler.Handle(todo);

            newTodo.Text.Should().BeEquivalentTo(todo.Text);
        }
    }
}
