using System;
using System.Collections.Generic;
using zmqClusteredHashmap.MessageFrames;

namespace zmqClusteredHashmap.Commands
{
    public class KVSetCommand : ICommand
    {
        public IEnumerable<IMessageFrame> MessageFrames
        {
            get { return _messageFrames; }
        }

        readonly List<IMessageFrame> _messageFrames;

        public KVSetCommand(KeyValueMessage message)
        {
            _messageFrames = new List<IMessageFrame>
                {
                    new StringMessageFrame(message.Key),
                    new BinaryMessageFrame(BitConverter.GetBytes(message.Sequence)),
                    message.UUID.HasValue? (IMessageFrame) new BinaryMessageFrame(message.UUID.Value.ToByteArray()) : new EmptyMessageFrame(),
                    new StringMessageFrame(message.EncodeProperties()),
                    new BinaryMessageFrame(message.Body)
                };
        }
    }
}