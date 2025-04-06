using Microsoft.AspNetCore.Components;

namespace Bleditor
{
    public abstract class BleditorBase<TCommand> : ComponentBase, IBleditorCommands<TCommand> where TCommand : Enum
    {
        public abstract IReadOnlyCollection<TCommand> Commands { get; }
        public abstract Task Execute(TCommand command);

    }
}