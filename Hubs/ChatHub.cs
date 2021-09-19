using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace SunkiojiDalis.Hubs
{
    public class Player {
        private int x;
        private int y;
        private int width;
        private int height;
        private int frameX;
        private int frameY;
        private int speed;
        private bool moving;
        private string sprite;

        public Player(int x, int y, int width, int height, int frameX, int frameY, int speed, bool moving, string sprite) {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.frameX = frameX;
            this.frameY = frameY;
            this.speed = speed;
            this.moving = moving;
            this.sprite = sprite;
        }
    }


    public class ChatHub : Hub
    {
        public List<Player> players = new List<Player>();
        public async Task JoinGame(string player)
        {
            Console.WriteLine(players);
            var convertedPlayer = Newtonsoft.Json.JsonConvert.DeserializeObject<Player>(player);
            players.Add(convertedPlayer);
            await Clients.All.SendAsync("AllPlayers", Newtonsoft.Json.JsonConvert.SerializeObject(players));
        }
    }
}