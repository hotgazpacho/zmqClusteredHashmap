using System.Linq;
using Machine.Specifications;
using zmqClusteredHashmap.Commands;
using zmqClusteredHashmap.MessageFrames;

namespace zmqClusteredHashmap.Specs.Commands.HUGZ
{
    [Subject(typeof(HugzCommand))]
    public class creating
    {
        static ICommand command;

        Because of = () => command = new HugzCommand();

        It should_have_five_message_frames = () => command.MessageFrames.Count().ShouldEqual(5);

        It should_have_the_string_HUGZ_as_the_first_frame =
            () => command.MessageFrames.First().Content.ShouldEqual("HUGZ");

        It should_have_a_string_of_eight_zeros_as_the_second_frame =
            () => command.MessageFrames.Skip(1).Take(1).Single().Content.ShouldEqual("00000000");

        It should_have_the_last_three_frames_be_empty_frames =
            () => command.MessageFrames.Skip(2).Take(3).ShouldEachConformTo(x => x is EmptyMessageFrame);

    }
}