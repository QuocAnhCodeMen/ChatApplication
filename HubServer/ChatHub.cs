using ChatContracts;
using Microsoft.AspNetCore.SignalR;

namespace HubServer;

public class ChatHub:Hub
{
    private ILogger<ChatHub> _logger;

    private static List<ConnectedUser> _connectedUsers = new();//rare condition
    private static readonly object _lock = new object();
    public ChatHub(ILogger<ChatHub> logger)
    {
        _logger = logger;
    }
    public override async Task OnConnectedAsync()
    {
        _logger.LogInformation("Client nao do da ket noi den HubServer");
       

        var userName = string.Empty;
        var userId = string.Empty;
        userName = Context.GetHttpContext()?.Request.Query["username"];
        userId = Context.GetHttpContext()?.Request.Query["userid"];
        var connectedUser = new ConnectedUser()
        {
            UserId = "",
            UserName = userName,
            ConnectedId = Context.ConnectionId
        };
        lock (_lock)
        {
            _connectedUsers.Add(connectedUser);
        }
       
        await Clients.Caller
           .SendAsync("SystemMessage", $"Hello {userName} Cám ơn vì daden");
        await Clients.All
            .SendAsync("UpdateListConnectedUsers", _connectedUsers);
        await base.OnConnectedAsync();
    }
    public override async  Task OnDisconnectedAsync(Exception? exception)
    {
        
        lock (_lock)
        {

            var user = _connectedUsers
                .FirstOrDefault(u => u.ConnectedId == Context.ConnectionId);
            if (user != null) {
                _connectedUsers.Remove(user);
            }


        }
        await Clients.All
            .SendAsync("UpdateListConnectedUsers", _connectedUsers);

        await base.OnDisconnectedAsync(exception);
        
    }
        
       
       

}

