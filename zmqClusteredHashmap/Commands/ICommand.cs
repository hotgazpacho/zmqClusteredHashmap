using System.Collections.Generic;
using zmqClusteredHashmap.MessageFrames;

namespace zmqClusteredHashmap.Commands
{
    public interface ICommand
    {
        IEnumerable<IMessageFrame> MessageFrames { get; }
    }
}