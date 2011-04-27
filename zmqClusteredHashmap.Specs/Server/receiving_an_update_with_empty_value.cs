using Machine.Specifications;

namespace zmqClusteredHashmap.Specs.Server
{
    [Subject(typeof(ClusteredHashmapServer), "Receiving an update with an empty value whose key corresponds to a key in the hashtable")]
    public class receiving_an_update_with_empty_value
    {
        It removes_the_message_with_the_matching_key_from_the_hashtable;
    }
}