using System.Collections.Generic;
using System.Text;
using Machine.Specifications;

namespace zmqClusteredHashmap.Specs.Server
{
    [Subject(typeof(ClusteredHashmapServer))]
    public class creating
    {
        static ClusteredHashmapServer server;
        static string host;
        static uint port;
        static Encoding encoding;
        static IDictionary<string, KeyValueMessage> messagesHashmap;

        Establish context = () =>
        {
            host = "localhost";
            port = 43325;
            encoding = Encoding.Unicode;
            messagesHashmap = new Dictionary<string, KeyValueMessage>();
        };

        Because of = () => server = new ClusteredHashmapServer(host, port, encoding, messagesHashmap);

        It should_have_the_correct_HostAddress = () => server.HostAddress.ShouldEqual(host);
        It should_have_the_correct_SnapshotPort = () => server.SnapshotPort.ShouldEqual(port);
        It should_have_the_correct_PublisherPort = () => server.PublisherPort.ShouldEqual(port + 1);
        It should_have_the_correct_CollectorPort = () => server.CollectorPort.ShouldEqual(port + 2);
        It should_have_the_correct_Encoding = () => server.Encoding.ShouldEqual(encoding);
    }
}
