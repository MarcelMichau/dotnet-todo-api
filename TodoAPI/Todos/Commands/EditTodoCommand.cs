using MediatR;

namespace TodoAPI.Todos.Commands;
public class EditTodoCommand : IRequest
{
    public int Id { get; }
    public Todo Todo {  get; }

    public EditTodoCommand(int id, Todo todo)
    {
        Id = id;
        Todo = todo;
    }

    public class EditTodoCommandHandler : IRequestHandler<EditTodoCommand>
    {
        private readonly TodoRepository _repository;

        public EditTodoCommandHandler(TodoRepository repository)
        {
            _repository = repository;
        }

        public Task<Unit> Handle(EditTodoCommand request, CancellationToken cancellationToken)
        {
            _repository.EditTodo(request.Id, request.Todo);
            return Unit.Task;
        }
    }
}
