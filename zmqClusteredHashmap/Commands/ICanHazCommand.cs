using System.Collections.Generic;
using zmqClusteredHashmap.MessageFrames;

namespace zmqClusteredHashmap.Commands
{
    public class ICanHazCommand : ICommand
    {
        readonly List<IMessageFrame> _messageFrames;
        public IEnumerable<IMessageFrame> MessageFrames
        {
            get { return _messageFrames.AsReadOnly(); }
        }

        public ICanHazCommand() : this(string.Empty)
        {
        }

        public ICanHazCommand(string subtreeSpecification)
        {
            _messageFrames = new List<IMessageFrame>
                {
                    new StringMessageFrame("ICANHAZ?"),
                    new StringMessageFrame(subtreeSpecification)
                };
        }

    }
}
