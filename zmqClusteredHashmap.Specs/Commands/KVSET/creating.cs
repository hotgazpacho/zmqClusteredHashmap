using System;
using System.Linq;
using System.Text;
using Machine.Specifications;
using zmqClusteredHashmap.Commands;

namespace zmqClusteredHashmap.Specs.Commands.KVSET
{
    [Subject(typeof(KVSetCommand))]
    public class creating
    {
        static ICommand command;
        static KeyValueMessage message;

        Establish context = () =>
        {
            message = new KeyValueMessage("My Key", long.MinValue)
            {
                UUID = Guid.NewGuid(),
                Body = Encoding.Unicode.GetBytes("This is my Message")
            };
            message.Properties.Add("ttl", "10000");
            message.Properties.Add("foo", "bar");
        };

        Because of = () => command = new KVSetCommand(message);

        It should_have_five_message_frames = () => command.MessageFrames.Count().ShouldEqual(5);

        It should_have_the_first_frame_be_the_key =
            () => command.MessageFrames.First().Content.ShouldEqual(message.Key);

        It should_have_the_second_frame_be_the_sequence =
            () =>
            command.MessageFrames.Skip(1).Take(1).Single().Content.ShouldEqual(
                BitConverter.GetBytes(message.Sequence));

        It should_have_the_third_frame_be_the_uuid =
            () =>
            command.MessageFrames.Skip(2).Take(1).Single().Content.ShouldEqual(message.UUID.Value.ToByteArray());

        It should_have_the_fourth_frame_be_the_encoded_properties_string =
            () => command.MessageFrames.Skip(3).Take(1).Single().Content.ShouldEqual(message.EncodeProperties());

        It should_have_the_fifth_frame_be_the_body_of_the_message =
            () => command.MessageFrames.Last().Content.ShouldEqual(message.Body);

    }
}