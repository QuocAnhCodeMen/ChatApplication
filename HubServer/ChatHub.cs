using Microsoft.AspNetCore.SignalR;

namespace HubServer;

public class ChatHub:Hub
{
    private ILogger<ChatHub> _logger;
    public ChatHub(ILogger<ChatHub> logger)
    {
        _logger = logger;
    }
    public override async Task OnConnectedAsync()
    {
        _logger.LogInformation("Client nao do da ket noi den HubServer");
        await Clients.Caller
            .SendAsync("SystemMessage", $"Hello {Context.ConnectionId} Cám ơn vì daden");

        var userName = string.Empty;
        userName = Context.GetHttpContext()?.Request.Query["username"];
        _logger.LogInformation("UserName: " + userName);
        await base.OnConnectedAsync();
    }
}
