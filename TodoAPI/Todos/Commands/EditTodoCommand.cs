
namespace TodoAPI.Todos.Commands;
public class EditTodoCommand
{
    private readonly TodoRepository _repository;

    public EditTodoCommand(TodoRepository repository)
    {
        _repository = repository;
    }

    public void Handle(int id, Todo todo)
    {
        _repository.EditTodo(id, todo);
    }
}
