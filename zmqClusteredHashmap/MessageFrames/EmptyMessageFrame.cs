namespace zmqClusteredHashmap.MessageFrames
{
    public class EmptyMessageFrame : IMessageFrame
    {
        public object Content
        {
            get { return string.Empty; }
        }
    }
}