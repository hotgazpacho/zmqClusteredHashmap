using Machine.Specifications;

namespace zmqClusteredHashmap.Specs.Server
{
    [Subject(typeof(ClusteredHashmapServer), "Responding to an synchronization command with many messages")]
    public class sync_with_many_messages_in_the_hashtable
    {
        It first_sends_an_ordered_series_of_KVSYNC_commands;
        It sends_a_KTHXBAI_command;
    }
}