using System.Text;
using Machine.Specifications;

namespace zmqClusteredHashmap.Specs.Client
{
    [Subject(typeof(ClusteredHashmapClient))]
    public class starting
    {
        It sends_an_ICANHAZ_command_on_the_snapshot_connection;
    }
}