using Machine.Specifications;

namespace zmqClusteredHashmap.Specs.Client
{
    [Subject(typeof(ClusteredHashmapClient))]
    public class sending_an_update
    {
        It sends_a_KVSET_command_on_the_publisher_connection;
    }
}