using Microsoft.AspNetCore.Components;

namespace Bleditor
{
    public class Bleditor : BleditorBase<BleditorCommands>
    {
        /// <summary>
        /// Applied to root tag
        /// </summary>
        [Parameter]
        public string Class { get; set; } = string.Empty;
        /// <summary>
        /// Applied to root tag
        /// </summary>
        [Parameter]
        public string Style { get; set; } = string.Empty;
        [Parameter]
        public string RootHtmlTag { get; set; } = "div";
        /// <summary>
        /// In case there is more than once instance, it only gets calculated once. Readonly ensures it's only computed once. 
        /// </summary>
        public override IReadOnlyCollection<BleditorCommands> Commands => _commands;
        private static readonly IReadOnlyCollection<BleditorCommands> _commands = Enum.GetValues(typeof(BleditorCommands)).Cast<BleditorCommands>().ToList();
        public override Task Execute(BleditorCommands command)
        {
            return Task.CompletedTask;
        }
    }
}
