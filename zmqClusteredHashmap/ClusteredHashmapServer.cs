using System.Collections.Generic;
using System.Text;
using ZMQ;

namespace zmqClusteredHashmap
{
    public class ClusteredHashmapServer
    {
        public string HostAddress { get; private set; }
        public uint SnapshotPort { get; private set; }
        public uint PublisherPort { get; private set; }
        public uint CollectorPort { get; private set; }
        public Encoding Encoding { get; private set; }
        
        readonly IDictionary<string, KeyValueMessage> _messages;

        public ClusteredHashmapServer(string hostAddress, uint port, Encoding encoding, IDictionary<string, KeyValueMessage> messages)
        {
            HostAddress = hostAddress;
            SnapshotPort = port;
            PublisherPort = port + 1;
            CollectorPort = port + 2;
            Encoding = encoding;
            _messages = messages;
        }

        public void Start()
        {
            using (var context = new Context(1))
            using (Socket snapshot  = context.Socket(SocketType.XREP),
                          publisher = context.Socket(SocketType.PUB),
                          collector = context.Socket(SocketType.SUB))
            {
                snapshot.Bind(Transport.TCP, HostAddress, SnapshotPort);
                publisher.Bind(Transport.TCP, HostAddress, PublisherPort);
                collector.Bind(Transport.TCP, HostAddress, CollectorPort);
            }
        }
    }
}
