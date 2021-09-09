
namespace TodoAPI.Todos;
public class GetTodos
{
    private readonly TodoRepository _repository;

    public GetTodos(TodoRepository repository)
    {
        _repository = repository;
    }

    public List<Todo> Handle()
    {
        return _repository.GetTodos();
    }
}
