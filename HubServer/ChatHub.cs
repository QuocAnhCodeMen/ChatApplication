using Microsoft.AspNetCore.SignalR;

namespace HubServer;

public class ChatHub:Hub
{
    private ILogger<ChatHub> _logger;
    public ChatHub(ILogger<ChatHub> logger)
    {
        _logger = logger;
    }
    public override Task OnConnectedAsync()
    {
        _logger.LogInformation("Client nao do da ket noi den HubServer");
        Clients.Caller
            .SendAsync("SystemMessage", $"Hello {Context.ConnectionId} Cám ơn vì daden");
        return base.OnConnectedAsync();
    }
}
