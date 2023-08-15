using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace UserSupportSystem.ChatApp.ChatHubs
{
    public class ChatHub : Hub
    {
        //private readonly ChatApiClient _chatApiClient;

        //public ChatHub(ChatApiClient chatApiClient)
        //{
        //    _chatApiClient = chatApiClient;
        //}
        public static int GetCount()
        {
            return 10;
        }
        public async Task SendMessage(string user, string message, string groupname)
        {
            // Make API call to get the Agent and details
            /*This will get Agent ID  to post message if the it's new
            required for new request which needs need agent allocation */

            //var data = await _chatApiClient.SupportRequestAsync();

            await Clients.Group(groupname).SendAsync("ReceiveMessage", user, message);

        }

        public async Task AddToGroup(string user, string groupname)
        {
            if (groupname==null || groupname =="")
            {
                var groupId = Guid.NewGuid();
                await Groups.AddToGroupAsync(Context.ConnectionId, groupId.ToString());

                await Clients.Group(groupId.ToString()).SendAsync("JoinGroup", $"{user} has joined the group.", groupId.ToString());
            }
            else
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, groupname);
                await Clients.Group(groupname).SendAsync("JoinGroup", $"{user} has joined the group.", groupname);
            }
        }

        public async Task RemoveFromGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
            await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has left the group {groupName}.");
        }
    }
}
