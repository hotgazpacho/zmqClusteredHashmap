using Machine.Specifications;

namespace zmqClusteredHashmap.Specs.Server
{
    [Subject(typeof(ClusteredHashmapServer), "Publishing one update")]
    public class hashtable_updated
    {
        It sends_a_KVPUB_command_on_the_publisher_socket;
    }
}