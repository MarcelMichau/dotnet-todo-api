
using MediatR;

namespace TodoAPI.Todos.Queries;
public class GetTodosQuery : IRequest<List<Todo>>
{
    public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, List<Todo>>
    {
        private readonly TodoRepository _repository;

        public GetTodosQueryHandler(TodoRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Todo>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.GetTodos());
        }
    }
}
