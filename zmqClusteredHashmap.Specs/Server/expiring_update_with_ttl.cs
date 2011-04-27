using Machine.Specifications;

namespace zmqClusteredHashmap.Specs.Server
{
    [Subject(typeof(ClusteredHashmapServer), "Expiring an update with a ttl property")]
    public class expiring_update_with_ttl
    {
        It removes_the_message_from_the_hashtable;
        It publishes_the_message_as_a_KVPUB_command_with_an_empty_value;
    }
}