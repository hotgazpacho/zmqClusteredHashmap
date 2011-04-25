namespace zmqClusteredHashmap.MessageFrames
{
    public class BinaryMessageFrame : IMessageFrame
    {
        readonly byte[] _content;
        public BinaryMessageFrame(byte[] content)
        {
            _content = content;
        }

        public object Content
        {
            get { return _content; }
        }
    }
}