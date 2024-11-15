using Microsoft.AspNetCore.SignalR;
namespace ST10298613_PROG6212_POE.NewFolder
{
    public class ClaimStatusHub:Hub
    {
        public async Task NotifyStatusChange(int claimId, string newStatus)
        {
            await Clients.All.SendAsync("ReceiveStatusUpdate", claimId, newStatus);
        }
    }
}
