
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;

namespace PlanningPokerSignalR.Hubs;

public class SessionManagerHub : Hub
{
    public async Task JoinSession(string sessionCode)
    {
        Debug.WriteLine($"SignalR group created for session {sessionCode}");
        await Groups.AddToGroupAsync(Context.ConnectionId, sessionCode);
        Debug.WriteLine($"Client with ConnectionId {Context.ConnectionId} joined session: {sessionCode}");
    }

    public async Task PlayerJoined(string sessionCode)
    {
        Debug.WriteLine($"Player joined session {sessionCode}");
        await Clients.Group(sessionCode).SendAsync("playerJoined", sessionCode);
    }
    public async Task SessionActive(string sessionCode)
    {
        await Clients.Group(sessionCode).SendAsync("sessionActive", sessionCode);
    }

    public async Task VoteCast(string sessionCode, int userId)
    {
        await Clients.Group(sessionCode).SendAsync("voteCast", sessionCode, userId);
    }

    public async Task ResetVotes(string sessionCode)
    {
        await Clients.Group(sessionCode).SendAsync("resetVotes", sessionCode);
    }

    public async Task ShowVotes(string sessionCode)
    {
        await Clients.Group(sessionCode).SendAsync("showVotes", sessionCode);
    }
    public async Task PlayerHighlight(string sessionCode, int userId)
    {
        await Clients.Group(sessionCode).SendAsync("playerHighlight", sessionCode, userId);
    }
}