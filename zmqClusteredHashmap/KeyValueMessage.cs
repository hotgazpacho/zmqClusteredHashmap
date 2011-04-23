using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZMQ;

namespace zmqClusteredHashmap
{
    public class KeyValueMessage
    {
        const int KeyValueMessageFrames = 5;

        public string Key { get; private set; }

        public long Sequence { get; private set; }

        public Guid? UUID { get; set; }

        public IDictionary<string, string> Properties { get; set; }

        public byte[] Body { get; set; }

        static readonly IList<Action<KeyValueMessage, byte[], Encoding>> FrameReceiveMap;

        static KeyValueMessage()
        {
            FrameReceiveMap = new List<Action<KeyValueMessage, byte[], Encoding>>
                {
                    (message, bytes, encoding) => message.Key = encoding.GetString(bytes),
                    (message, bytes, encoding) => message.Sequence = Convert.ToInt64(bytes),
                    (message, bytes, encoding) => message.UUID = new Guid(bytes),
                    (message, bytes, encoding) => message.Properties = DecodeProperties(encoding.GetString(bytes)),
                    (message, bytes, encoding) => message.Body = bytes,
                };
        }

        public KeyValueMessage(string key, long sequence)
        {
            Key = key;
            Sequence = sequence;
            Properties = new Dictionary<string, string>();
        }

        public string EncodeProperties()
        {
            return string.Join("", Properties.Select(x => string.Format("{0}={1}\n", x.Key, x.Value)));
        }

        public static IDictionary<string, string> DecodeProperties(string encodedProperties)
        {
            return encodedProperties
                .Split(new[] {"\n"}, StringSplitOptions.None)
                .Select(encodedKeyValuePair => encodedKeyValuePair.Split('='))
                .ToDictionary(kvpSplit => kvpSplit[0], kvpSplit => kvpSplit[1]);
        }

        public KeyValueMessage Duplicate(KeyValueMessage message)
        {
            var keyValueMessage = new KeyValueMessage(Key, Sequence)
                {
                    UUID = UUID,
                };
            Body.CopyTo(keyValueMessage.Body, 0);
            foreach (var property in Properties)
            {
                keyValueMessage.Properties.Add(property.Key, property.Value);
            }
            return keyValueMessage;
        }

        public KeyValueMessage Receive(Socket socket, Encoding encoding)
        {
            var keyValueMessage = new KeyValueMessage(string.Empty, 0);
            for (int frameNumber = 0; frameNumber < KeyValueMessageFrames; frameNumber++)
            {
                var data = socket.Recv();
                if (data == null)
                {
                    keyValueMessage = null;
                    break;
                }

                var setter = FrameReceiveMap[frameNumber];
                setter(keyValueMessage, data, encoding);

                bool recvMore = frameNumber < KeyValueMessageFrames - 1 ? true : false;
                if (socket.RcvMore != recvMore)
                {
                    keyValueMessage = null;
                    break;
                }
            }

            return keyValueMessage;
        }
    }
}
