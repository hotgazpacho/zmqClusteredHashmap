using System.Text;
using ZMQ;

namespace zmqClusteredHashmap
{
    public class ClusteredHashmapClient
    {
        public string HostAddress { get; private set; }
        public uint SnapshotPort { get; private set; }
        public uint SubscriberPort { get; private set; }
        public uint PublisherPort { get; private set; }
        public Encoding Encoding { get; private set; }

        public ClusteredHashmapClient(string hostAddress, uint port, Encoding encoding)
        {
            HostAddress = hostAddress;
            SnapshotPort = port;
            SubscriberPort = port + 1;
            PublisherPort = port + 2;
            Encoding = encoding;
        }

        public void Start()
        {
            using (var context = new Context(1))
            using (Socket snapshot   = context.Socket(SocketType.XREQ),
                          subscriber = context.Socket(SocketType.SUB),
                          publisher  = context.Socket(SocketType.PUB))
            {
                snapshot.Connect(string.Format("tcp://{0}:{1}", HostAddress, SnapshotPort));
                subscriber.Bind(string.Format("tcp://{0}:{1}", HostAddress, SubscriberPort));
                publisher.Bind(string.Format("tcp://{0}:{1}", HostAddress, PublisherPort));
            }
        }
    }
}
