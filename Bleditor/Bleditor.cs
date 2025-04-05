using Microsoft.AspNetCore.Components;

namespace Bleditor
{
    public class Bleditor : BleditorBase<BleditorDefaultCommands>
    {
        [Parameter]
        public string Class { get; set; } = string.Empty;
        [Parameter]
        public string Style { get; set; } = string.Empty;
        /// <summary>
        /// In case there is more than once instance, it only gets calculated once. Readonly ensures it's only computed once. 
        /// </summary>
        public override IReadOnlyCollection<BleditorDefaultCommands> Commands => _commands;

        private static readonly IReadOnlyCollection<BleditorDefaultCommands> _commands = Enum.GetValues(typeof(BleditorDefaultCommands)).Cast<BleditorDefaultCommands>().ToList();
        public override Task Execute(BleditorDefaultCommands command)
        {
            return Task.CompletedTask;
        }
    }
}
