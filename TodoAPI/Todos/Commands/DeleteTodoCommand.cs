
using MediatR;

namespace TodoAPI.Todos.Commands;
public class DeleteTodoCommand : IRequest
{
    public int Id { get; }

    public DeleteTodoCommand(int id)
    {
        Id = id;
    }

    public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand>
    {
        private readonly TodoRepository _repository;

        public DeleteTodoCommandHandler(TodoRepository repository)
        {
            _repository = repository;
        }

        public Task<Unit> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            _repository.DeleteTodo(request.Id);
            return Unit.Task;
        }
    }
}
