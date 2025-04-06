namespace Bleditor.Rendering
{
    internal class RenderInstructionGroup(int groupNumber, RenderInstruction openingElement, RenderInstruction groupNumberAttribute, RenderInstruction textNode, RenderInstruction closingElement, List<RenderInstruction>? additionalAttributes = null)
    {
        public int GroupNumber { get; init; } = groupNumber;
        public List<RenderInstruction>? AdditionalAttributeNodes { get; set; } = additionalAttributes;
        public RenderInstruction OpeningElement { get; set; } = openingElement;
        public RenderInstruction GroupNumberAttribute { get; set; } = groupNumberAttribute;
        public RenderInstruction TextNode { get; set; } = textNode;
        public RenderInstruction ClosingElement { get; set; } = closingElement;
    }
}
