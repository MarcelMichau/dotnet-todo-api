using MediatR;

namespace TodoAPI.Todos.Commands;
public class EditTodoCommand : IRequest
{
    public int Id { get; init; }
    public EditableTodo Todo { get; init; }

    public EditTodoCommand(int id, EditableTodo todo)
    {
        Id = id;
        Todo = todo;
    }

    public class EditTodoCommandHandler : IRequestHandler<EditTodoCommand>
    {
        private readonly TodoRepository _repository;

        public EditTodoCommandHandler(TodoRepository repository)
        {
            _repository = repository;
        }

        public Task<Unit> Handle(EditTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = new Todo
            {
                Text = request.Todo.Text,
                IsCompleted = request.Todo.IsCompleted
            };

            _repository.EditTodo(request.Id, todo);
            return Unit.Task;
        }
    }

    public class EditableTodo
    {
        public string Text { get; init; }
        public bool IsCompleted { get; init; }
    }
}
