using System.Text;
using Machine.Specifications;

namespace zmqClusteredHashmap.Specs.Client
{
    [Subject(typeof(ClusteredHashmapClient))]
    public class creating
    {
        static ClusteredHashmapClient client;
        static string host;
        static uint port;
        static Encoding encoding;

        Establish context = () =>
            {
                host = "localhost";
                port = 43325;
                encoding = Encoding.Unicode;
            };

        Because of = () => client = new ClusteredHashmapClient(host, port, encoding);

        It should_have_the_correct_HostAddress = () => client.HostAddress.ShouldEqual(host);
        It should_have_the_correct_SnapshotPort = () => client.SnapshotPort.ShouldEqual(port);
        It should_have_the_correct_SubscriberPort = () => client.SubscriberPort.ShouldEqual(port + 1);
        It should_have_the_correct_PublisherPort = () => client.PublisherPort.ShouldEqual(port + 2);
        It should_have_the_correct_Encoding = () => client.Encoding.ShouldEqual(encoding);
    }
}
