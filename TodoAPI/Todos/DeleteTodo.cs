
namespace TodoAPI.Todos;
public class DeleteTodo
{
    private readonly TodoRepository _repository;

    public DeleteTodo(TodoRepository repository)
    {
        _repository = repository;
    }

    public void Handle(int id)
    {
        _repository.DeleteTodo(id);
    }
}
