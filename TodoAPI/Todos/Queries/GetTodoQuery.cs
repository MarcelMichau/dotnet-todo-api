
using MediatR;

namespace TodoAPI.Todos.Queries;
public class GetTodoQuery : IRequest<Todo>
{
    public int Id { get; }

    public GetTodoQuery(int id)
    {
        Id = id;
    }

    public class GetTodoQueryHandler : IRequestHandler<GetTodoQuery, Todo>
    {
        private readonly TodoRepository _repository;

        public GetTodoQueryHandler(TodoRepository repository)
        {
            _repository = repository;
        }

        public Task<Todo> Handle(GetTodoQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.GetTodo(request.Id));
        }
    }
}
