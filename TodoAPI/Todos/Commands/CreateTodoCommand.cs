using MediatR;

namespace TodoAPI.Todos.Commands;
public class CreateTodoCommand : IRequest<Todo>
{
    public string TodoText { get; init; }

    public CreateTodoCommand(string todoText)
    {
        TodoText = todoText;
    }

    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, Todo>
    {
        private readonly TodoRepository _repository;

        public CreateTodoCommandHandler(TodoRepository repository)
        {
            _repository = repository;
        }

        public Task<Todo> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            var newTodo = new Todo
            {
                Text = request.TodoText
            };

            return Task.FromResult(_repository.AddTodo(newTodo));
        }
    }
}
