
namespace TodoAPI.Todos.Queries;
public class GetTodosQuery
{
    private readonly TodoRepository _repository;

    public GetTodosQuery(TodoRepository repository)
    {
        _repository = repository;
    }

    public List<Todo> Handle()
    {
        return _repository.GetTodos();
    }
}
