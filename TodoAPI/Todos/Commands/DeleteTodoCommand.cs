
namespace TodoAPI.Todos.Commands;
public class DeleteTodoCommand
{
    private readonly TodoRepository _repository;

    public DeleteTodoCommand(TodoRepository repository)
    {
        _repository = repository;
    }

    public void Handle(int id)
    {
        _repository.DeleteTodo(id);
    }
}
