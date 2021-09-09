
namespace TodoAPI.Todos;
public class EditTodo
{
    private readonly TodoRepository _repository;

    public EditTodo(TodoRepository repository)
    {
        _repository = repository;
    }

    public void Handle(int id, Todo todo)
    {
        _repository.EditTodo(id, todo);
    }
}
