using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SessiaApi
{
    public class ChatHub : Hub
    {
        // Вход в чат по заявке (группы по заявке)
        public async Task JoinRequestChat(int requestId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"request_{requestId}");
        }

        // Отправка сообщения в чат заявки
        public async Task SendMessage(int requestId, int userId, string userName, string message)
        {
            await Clients.Group($"request_{requestId}").SendAsync("ReceiveMessage", userId, userName, message, System.DateTime.Now);
        }
    }
} 