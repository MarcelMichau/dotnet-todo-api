
namespace TodoAPI.Todos;
public class GetTodo
{
    private readonly TodoRepository _repository;

    public GetTodo(TodoRepository repository)
    {
        _repository = repository;
    }

    public Todo Handle(int id)
    {
        return _repository.GetTodo(id);
    }
}
