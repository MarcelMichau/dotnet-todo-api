namespace TodoAPI.Todos.Commands;
public class CreateTodoCommand
{
    private readonly TodoRepository _repository;

    public CreateTodoCommand(TodoRepository repository)
    {
        _repository = repository;
    }

    public Todo Handle(Todo todo)
    {
        return _repository.AddTodo(todo);
    }
}
