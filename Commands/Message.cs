
using Newtonsoft.Json;

namespace SignalRWebPack
{
    [JsonObject(MemberSerialization.Fields)]
    public class Message
    {
        public readonly string message = "";

        public readonly string id;

        public Message(string message, string id)
        {
            this.message = message;
            this.id = id;
        }
    }
}