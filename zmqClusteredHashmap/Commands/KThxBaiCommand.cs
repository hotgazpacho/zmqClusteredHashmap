using System;
using System.Collections.Generic;
using zmqClusteredHashmap.MessageFrames;

namespace zmqClusteredHashmap.Commands
{
    public class KThxBaiCommand : ICommand
    {
        public IEnumerable<IMessageFrame> MessageFrames
        {
            get { return _messageFrames; }
        }

        readonly List<IMessageFrame> _messageFrames;

        public KThxBaiCommand(long sequence, string subtreeSpecification)
        {
            _messageFrames = new List<IMessageFrame>
                {
                    new StringMessageFrame("KTHXBAI"),
                    new BinaryMessageFrame(BitConverter.GetBytes(sequence)),
                    new EmptyMessageFrame(),
                    new EmptyMessageFrame(),
                    new StringMessageFrame(subtreeSpecification)
                };
        }
    }
}