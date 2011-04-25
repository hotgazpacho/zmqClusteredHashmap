using System.Linq;
using Machine.Specifications;
using zmqClusteredHashmap.Commands;

namespace zmqClusteredHashmap.Specs.Commands.ICANHAZ
{
    [Subject(typeof(ICanHazCommand))]
    public class create_with_valid_subtree_specification
    {
        protected static ICommand command;
        static string subtreeSpecification;

        Establish context = () => subtreeSpecification = "/Path/To/Subtree/";

        Because of = () => command = new ICanHazCommand(subtreeSpecification);

        Behaves_like<ICanHazCommandBehaviors> an_ICanHazCommand;

        It should_have_the_second_message_be_an_empty_string =
            () => command.MessageFrames.Last().Content.ShouldEqual(subtreeSpecification);
    }
}