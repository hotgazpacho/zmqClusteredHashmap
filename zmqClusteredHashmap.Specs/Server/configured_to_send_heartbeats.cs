using Machine.Specifications;

namespace zmqClusteredHashmap.Specs.Server
{
    [Subject(typeof(ClusteredHashmapServer), "Sending heartbeats")]
    public class configured_to_send_heartbeats
    {
        It sends_a_HUGZ_command_once_per_the_configured_interval;
    }
}