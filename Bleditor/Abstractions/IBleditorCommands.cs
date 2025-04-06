using Microsoft.AspNetCore.Components;

namespace Bleditor
{
    public interface IBleditorCommands<TCommand> where TCommand : Enum
    {
        public Task Execute(TCommand command);
        IReadOnlyCollection<TCommand> Commands { get; }
    }
}
