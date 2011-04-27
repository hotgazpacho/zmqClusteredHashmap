using Machine.Specifications;

namespace zmqClusteredHashmap.Specs.Server
{
    [Subject(typeof(ClusteredHashmapServer), "Responding to an synchronization command with one message")]
    public class sync_with_one_message_in_the_hashtable
    {
        It first_sends_one_KVSYNC_command;
        It sends_a_KTHBAI_command;
    }
}