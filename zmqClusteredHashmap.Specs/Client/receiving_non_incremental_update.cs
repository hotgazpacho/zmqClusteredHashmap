using Machine.Specifications;

namespace zmqClusteredHashmap.Specs.Client
{
    [Subject(typeof(ClusteredHashmapClient), "Receiving update whose Sequence Number is not strictly incremental")]
    public class receiving_non_incremental_update
    {
        It discards_the_update;
    }
}