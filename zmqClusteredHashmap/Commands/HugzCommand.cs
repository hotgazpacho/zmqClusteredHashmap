using System.Collections.Generic;
using zmqClusteredHashmap.MessageFrames;

namespace zmqClusteredHashmap.Commands
{
    public class HugzCommand : ICommand
    {
        public IEnumerable<IMessageFrame> MessageFrames
        {
            get { return _messageFrames; }
        }

        readonly List<IMessageFrame> _messageFrames;

        public HugzCommand()
        {
            _messageFrames = new List<IMessageFrame>
                {
                    new StringMessageFrame("HUGZ"),
                    new StringMessageFrame(string.Empty.PadRight(8, '0')),
                    new EmptyMessageFrame(),
                    new EmptyMessageFrame(),
                    new EmptyMessageFrame()
                };
        }
    }
}