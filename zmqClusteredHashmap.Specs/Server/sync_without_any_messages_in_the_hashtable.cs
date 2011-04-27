using Machine.Specifications;

namespace zmqClusteredHashmap.Specs.Server
{
    [Subject(typeof(ClusteredHashmapServer), "Responding to an synchronization command without any messages")]
    public class sync_without_any_messages_in_the_hashtable
    {
        It does_not_send_a_KVSYNC_command;
        It sends_a_KTHXBAI_command;
    }
}