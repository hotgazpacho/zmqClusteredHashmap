using System;
using System.Collections.Generic;
using zmqClusteredHashmap.MessageFrames;

namespace zmqClusteredHashmap.Commands
{
    public class KVSyncCommand : ICommand
    {
        public IEnumerable<IMessageFrame> MessageFrames
        {
            get { return _messageFrames; }
        }

        readonly List<IMessageFrame> _messageFrames;

        public KVSyncCommand(string key, long sequence, byte[] message)
        {
            _messageFrames = new List<IMessageFrame>
                {
                    new StringMessageFrame(key),
                    new BinaryMessageFrame(BitConverter.GetBytes(sequence)),
                    new EmptyMessageFrame(),
                    new EmptyMessageFrame(),
                    new BinaryMessageFrame(message)
                };
        }
    }
}
