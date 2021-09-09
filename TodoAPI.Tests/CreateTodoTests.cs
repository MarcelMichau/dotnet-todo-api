using FluentAssertions;
using TodoAPI.Todos;
using Xunit;

namespace TodoAPI.Tests
{
    public class CreateTodoTests
    {
        [Fact]
        public async Task ShouldBeAbleToCreateTodo()
        {
            var repository = new TodoRepository();
            var handler = new CreateTodo(repository);

            var todo = new Todo
            {
                Text = "Write a Test"
            };

            var newTodo = handler.Handle(todo);

            newTodo.Text.Should().BeEquivalentTo(todo.Text);
        }
    }
}
