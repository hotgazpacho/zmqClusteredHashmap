namespace zmqClusteredHashmap.MessageFrames
{
    public class MessageFrame<T> : IMessageFrame
    {
        public object Content
        {
            get { return _content; }
        }

        readonly T _content;

        public MessageFrame(T content)
        {
            _content = content;
        }
    }
}