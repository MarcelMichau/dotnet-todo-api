
namespace TodoAPI.Todos.Queries;
public class GetTodoQuery
{
    private readonly TodoRepository _repository;

    public GetTodoQuery(TodoRepository repository)
    {
        _repository = repository;
    }

    public Todo Handle(int id)
    {
        return _repository.GetTodo(id);
    }
}
