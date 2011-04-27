using Machine.Specifications;

namespace zmqClusteredHashmap.Specs.Client
{
    [Subject(typeof(ClusteredHashmapClient), "Receiving update whose value is empty")]
    public class receiving_message_with_empty_value
    {
        It removes_the_message_from_its_local_hashtable;
    }
}