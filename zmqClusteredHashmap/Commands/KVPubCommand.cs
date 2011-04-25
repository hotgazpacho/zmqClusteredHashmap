using System;
using System.Collections.Generic;
using zmqClusteredHashmap.MessageFrames;

namespace zmqClusteredHashmap.Commands
{
    public class KVPubCommand : ICommand
    {
        public IEnumerable<IMessageFrame> MessageFrames
        {
            get { return _messageFrames; }
        }

        readonly List<IMessageFrame> _messageFrames;

        public KVPubCommand(KeyValueMessage message)
        {
            _messageFrames = new List<IMessageFrame>
                {
                    new MessageFrame<string>(message.Key),
                    new MessageFrame<byte[]>(BitConverter.GetBytes(message.Sequence)),
                    message.UUID.HasValue? (IMessageFrame) new MessageFrame<byte[]>(message.UUID.Value.ToByteArray()) : new EmptyMessageFrame(),
                    new MessageFrame<string>(message.EncodeProperties()),
                    new MessageFrame<byte[]>(message.Body)
                };
        }
    }
}