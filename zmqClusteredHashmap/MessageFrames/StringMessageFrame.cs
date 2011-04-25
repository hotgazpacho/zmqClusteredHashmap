namespace zmqClusteredHashmap.MessageFrames
{
    public class StringMessageFrame : IMessageFrame
    {
        readonly string _content;
        public object Content
        {
            get { return _content; }
        }

        public StringMessageFrame(string content)
        {
            _content = content;
        }
    }
}