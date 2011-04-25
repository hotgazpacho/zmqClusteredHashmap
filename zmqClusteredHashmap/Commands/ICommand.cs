using System.Collections.Generic;
using System.Collections.ObjectModel;
using zmqClusteredHashmap.MessageFrames;

namespace zmqClusteredHashmap.Commands
{
    public interface ICommand
    {
        IEnumerable<IMessageFrame> MessageFrames { get; }
    }
}