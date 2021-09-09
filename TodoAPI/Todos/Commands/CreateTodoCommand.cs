using MediatR;

namespace TodoAPI.Todos.Commands;
public class CreateTodoCommand : IRequest<Todo>
{
    public Todo Todo { get; }

    public CreateTodoCommand(Todo todo)
    {
        Todo = todo;
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
            return Task.FromResult(_repository.AddTodo(request.Todo));
        }
    }
}
