using Microsoft.AspNetCore.SignalR;
using SignalRChat.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        public Task Send(string message, string group)
        {
            var fromId = Context.ConnectionId;
            var client = ConnectionHelper.Connections.FirstOrDefault(c => c.ConnectionId.Equals(fromId));
            return Clients.Group(group).InvokeAsync("send", $"{DateTime.Now.ToShortTimeString()} {client.Name}: {message}");
        }

        public Task GetChatRoom1Members()
        {
            return Clients.All.InvokeAsync("GetChatRoom1Members", ConnectionHelper.Connections.Where(c => c.ChatRoom == ChatRoom.chatroom1));
        }

        public Task GetChatRoom2Members()
        {
            return Clients.All.InvokeAsync("GetChatRoom2Members", ConnectionHelper.Connections.Where(c => c.ChatRoom == ChatRoom.chatroom2));
        }

        public void RegisterMember(string name, string chatRoom)
        {
            var client = new MyClient();
            client.ConnectionId = Context.ConnectionId;
            client.Name = name;

            if (chatRoom == "chatRoom1")
            {
                client.ChatRoom = ChatRoom.chatroom1;
                Groups.AddAsync(Context.ConnectionId, "chatRoom1");
            }
            else if (chatRoom == "chatRoom2")
            {
                client.ChatRoom = ChatRoom.chatroom2;
                Groups.AddAsync(Context.ConnectionId, "chatRoom2");
            }

            ConnectionHelper.Connections.Add(client);
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var client = ConnectionHelper.Connections.FirstOrDefault(c => c.ConnectionId == Context.ConnectionId);

            if(client != null)
            {
                ConnectionHelper.Connections.Remove(client);
            }

            return base.OnDisconnectedAsync(exception);
        }

      
    }
}
