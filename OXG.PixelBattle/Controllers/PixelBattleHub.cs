using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OXG.PixelBattle.Controllers
{
    public class PixelBattleHub : Hub
    {
        public async Task Send(string x, string y, string color)
        {
            await this.Clients.All.SendAsync("Send", x, y, color);
        }
    }
}
