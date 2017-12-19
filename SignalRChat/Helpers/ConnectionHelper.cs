using System.Collections.Generic;

namespace SignalRChat.Helpers
{
    public static class ConnectionHelper
    {
        public static List<MyClient> Connections = new List<MyClient>();
    }

    public class MyClient
    {
        public string Name { get; set; }
        public ChatRoom ChatRoom { get; set; }
        public string ConnectionId { get; set; }
    }

    public enum ChatRoom
    {
        chatroom1,
        chatroom2
    }
}

