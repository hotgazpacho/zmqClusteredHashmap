using System.Linq;
using Machine.Specifications;
using zmqClusteredHashmap.Commands;

namespace zmqClusteredHashmap.Specs.Commands.ICANHAZ
{
    [Behaviors]
    public class ICanHazCommandBehaviors
    {
        protected static ICommand command;

        It should_have_two_StringMessageFrames =
            () => command.MessageFrames.Count().ShouldEqual(2);

        It should_have_the_first_message_be_ICANHAZ =
            () => command.MessageFrames.First().Content.ShouldEqual("ICANHAZ?");
    }
}