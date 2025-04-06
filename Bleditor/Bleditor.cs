using Bleditor.Rendering;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Bleditor
{
    public class Bleditor : BleditorBase<BleditorCommands>
    {
        private static readonly IReadOnlyCollection<BleditorCommands> _commands = Enum.GetValues(typeof(BleditorCommands)).Cast<BleditorCommands>().ToList();
        private readonly RenderInstructionListMap _renderInstructionListMap = [];
        protected CursorPosition _cursorPosition; //LEFT OFF HERE. CONSIDERING GETTING RID OF CursorPosition and just have Selection. 
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
        [Inject]
        private IJSRuntime JSRuntime { get; set; } = default!;
        /// <summary>
        /// In case there is more than once instance, it only gets calculated once. Readonly ensures it's only computed once. 
        /// </summary>
        public override IReadOnlyCollection<BleditorCommands> Commands => _commands;
        public override Task Execute(BleditorCommands command)
        {
            return Task.CompletedTask;
        }
    }
}
