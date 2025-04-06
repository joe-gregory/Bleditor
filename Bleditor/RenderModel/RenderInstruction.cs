using Microsoft.AspNetCore.Components.Rendering;

namespace Bleditor.Rendering
{
    internal class RenderInstruction(int sequence, Action<RenderTreeBuilder> instruction, string content = null!)
    {
        public int Sequence { get; set; } = sequence;
        public Action<RenderTreeBuilder> Instruction { get; set; } = instruction;
        public string Content { get; set; } = content;
        public RenderInstructionGroup Group { get; set; } = null!;
    }
}
