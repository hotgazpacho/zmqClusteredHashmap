using System;
using System.Linq;
using Machine.Specifications;
using zmqClusteredHashmap.Commands;
using zmqClusteredHashmap.MessageFrames;

namespace zmqClusteredHashmap.Specs.Commands.KTHXBAI
{
    [Subject(typeof(KThxBaiCommand))]
    public class creating
    {
        static ICommand command;
        static long sequence = long.MaxValue;
        static string subtreeSpecification = "/Sub/Tree/Specification";

        Because of = () => command = new KThxBaiCommand(sequence, subtreeSpecification);

        It should_have_five_message_frames = () => command.MessageFrames.Count().ShouldEqual(5);

        It should_have_KTHXBAI_as_the_first_frame = () => command.MessageFrames.First().Content.ShouldEqual("KTHXBAI");

        It should_have_the_sequence_number_as_the_second_frame =
            () =>
            command.MessageFrames.Skip(1).Take(1).Single().Content.ShouldEqual(BitConverter.GetBytes(sequence));

        It should_have_the_third_and_forth_frames_be_empty =
           () => command.MessageFrames.Skip(2).Take(2).ShouldEachConformTo(x => x is EmptyMessageFrame);

        It should_have_the_subtree_specification_as_the_last_frame =
            () => command.MessageFrames.Last().Content.ShouldEqual(subtreeSpecification);
    }
}