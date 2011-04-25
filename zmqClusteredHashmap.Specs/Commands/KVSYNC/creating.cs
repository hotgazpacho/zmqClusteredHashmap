using System;
using System.Linq;
using System.Text;
using Machine.Specifications;
using zmqClusteredHashmap.Commands;
using zmqClusteredHashmap.MessageFrames;

namespace zmqClusteredHashmap.Specs.Commands.KVSYNC
{
    [Subject(typeof(KVSyncCommand))]
    public class creating
    {
        static ICommand command;
        static string key;
        static byte[] sequence;
        static byte[] message;

        Establish context = () =>
            {
                key = "MyKey";
                sequence = BitConverter.GetBytes(long.MaxValue);
                message = Encoding.Unicode.GetBytes("This is my message");
            };

        Because of = () => command = new KVSyncCommand(key, long.MaxValue, message);

        It should_have_five_message_frames = () => command.MessageFrames.Count().ShouldEqual(5);

        It should_have_the_first_frame_be_the_key = () => command.MessageFrames.First().Content.ShouldEqual(key);

        It should_have_the_second_frame_be_the_sequence =
            () => command.MessageFrames.Skip(1).Take(1).Single().Content.ShouldEqual(sequence);

        It should_have_the_third_and_forth_frames_be_empty =
            () => command.MessageFrames.Skip(2).Take(2).ShouldEachConformTo(x => x is EmptyMessageFrame);

        It should_have_the_last_frame_be_the_message = () => command.MessageFrames.Last().Content.ShouldEqual(message);
    }
}