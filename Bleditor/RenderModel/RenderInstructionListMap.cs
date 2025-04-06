using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bleditor.Rendering
{
    /// <summary>
    /// Maintains an ordered collection of <see cref="RenderInstruction"/>s with
    /// both sequential access (linked list) and indexed lookup (dictionary).
    /// Designed to support Blator's custom render pipeline.
    /// </summary>
    internal class RenderInstructionListMap : IEnumerable<RenderInstruction>
    {
        private readonly LinkedList<RenderInstruction> _renderInstructions = [];
        private readonly Dictionary<int, LinkedListNode<RenderInstruction>> _renderInstructionMap = [];
        public LinkedListNode<RenderInstruction> AddLast(int sequence, Action<RenderTreeBuilder> action, string? content = null)
        {
            if (_renderInstructionMap.ContainsKey(sequence))
            {
                throw new ArgumentException($"Sequence number {sequence} already exists in the collection.");
            }
            LinkedListNode<RenderInstruction> listActionNode = _renderInstructions.AddLast(new RenderInstruction(sequence, action, content));
            _renderInstructionMap.Add(sequence, listActionNode);
            return listActionNode;
        }
        public LinkedListNode<RenderInstruction> AddLast(RenderInstruction actionNode)
        {
            LinkedListNode<RenderInstruction> listActionNode = _renderInstructions.AddLast(actionNode);
            _renderInstructionMap.Add(actionNode.Sequence, listActionNode);
            return listActionNode;
        }
        public LinkedListNode<RenderInstruction>? GetNodeBySequence(int sequence)
        {
            _renderInstructionMap.TryGetValue(sequence, out var node);
            return node;
        }
        public LinkedListNode<RenderInstruction> this[int sequence]
        {
            get
            {
                if (_renderInstructionMap.TryGetValue(sequence, out var node))
                {
                    return node;
                }
                throw new KeyNotFoundException($"No LinkedListNode<ActionNode> found for sequence {sequence}.");
            }
        }
        public LinkedListNode<RenderInstruction> FindNextTextNodeFromHere(int sequenceNumber)
        {
            if (sequenceNumber == 0)
            {
                int? firstSequenceNumber = _renderInstructions.First?.Value.Sequence;
                if (firstSequenceNumber == null) throw new Exception("Blator: there was no first element in _actions");
                else return FindNextTextNodeFromHere(firstSequenceNumber.Value);
            }
            if (_renderInstructionMap.TryGetValue(sequenceNumber, out LinkedListNode<RenderInstruction>? node))
            {
                while (node.Next != null)
                {
                    if (node.Next.Value.Content != null)
                    {
                        return node.Next;
                    }
                    node = node.Next;
                }
                throw new Exception("No text node found.");
            }
            else throw new KeyNotFoundException($"No LinkedListNode<ActionNode> found for sequence {sequenceNumber}.");
        }
        public void Remove(int sequence)
        {
            if (_renderInstructionMap.TryGetValue(sequence, out var node))
            {
                // Remove from the linked list
                _renderInstructions.Remove(node);

                // Remove from the dictionary
                _renderInstructionMap.Remove(sequence);
            }
            else
            {
                throw new KeyNotFoundException($"No ActionNode found for sequence {sequence}.");
            }
        }
        public IEnumerator<RenderInstruction> GetEnumerator()
        {
            return _renderInstructions.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
