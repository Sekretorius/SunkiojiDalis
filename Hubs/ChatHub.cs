using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Linq;
using SunkiojiDalis.Engine;
using SunkiojiDalis.Hubs.Worlds;
using System.Numerics;

namespace SunkiojiDalis.Hubs
{
    [JsonObject(MemberSerialization.Fields)]
    public class Player
    {
        private int id;
        public int x;
        public int y;
        private int width;
        private int height;
        private int frameX;
        private int frameY;
        private int speed;
        private bool moving;
        private string sprite;
        public int worldX;
        public int worldY;

        public Player(int id, int x, int y, int width, int height, int frameX, int frameY, int speed, bool moving, string sprite, int worldX, int worldY) {
            this.id = id;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.frameX = frameX;
            this.frameY = frameY;
            this.speed = speed;
            this.moving = moving;
            this.sprite = sprite;
            this.worldX = worldX;
            this.worldY = worldY;
            //to do: sync other actions 
        }

        public void setId(int id) {
            this.id = id;
        }

        public int getId() {
            return this.id;
        }

        public void MoveToArea(int stepX, int stepY, int x, int y)
        {
            worldX += stepX;
            worldY += stepY;
            this.x = x;
            this.y = y;
        }

        public string GetGroupId()
        {
            return $"{worldX},{worldY}";
        }
    }

    public static class PlayersList {
        public static Dictionary<int, Player> players = new Dictionary<int, Player>();
    }

    public class ChatHub : Hub
    {
        
        public async Task JoinGame(string player)
        {   
            Random rd = new Random();
            int rand_num = rd.Next(1, 99999);
            var convertedPlayer = Newtonsoft.Json.JsonConvert.DeserializeObject<Player>(player);
            convertedPlayer.setId(rand_num);
            PlayersList.players[rand_num] = convertedPlayer;
            await Clients.Caller.SendAsync("RecieveId", Newtonsoft.Json.JsonConvert.SerializeObject(convertedPlayer.getId()));

            World.Instance.AddPlayer(PlayersList.players[rand_num]);
            await Groups.AddToGroupAsync(Context.ConnectionId,convertedPlayer.GetGroupId());
            await Clients.Group(convertedPlayer.GetGroupId()).SendAsync("RecieveInfoAboutOtherPlayers", JsonConvert.SerializeObject(World.Instance.GetPlayers(convertedPlayer.worldX, convertedPlayer.worldY) ));

            await ServerEngine.NetworkManager.OnNewClientConnected(Clients.Caller);
        }

        public async Task MovePlayer(Player convertedPlayer, int worldX, int worldY, int x, int y)
        {
            World.Instance.MoveToArea(convertedPlayer, worldX, worldY, x, y);

            // Leaving the group
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, PlayersList.players[convertedPlayer.getId()].GetGroupId());
            await Clients.Group(PlayersList.players[convertedPlayer.getId()].GetGroupId()).SendAsync("RecieveInfoAboutOtherPlayers", JsonConvert.SerializeObject(World.Instance.GetPlayers(convertedPlayer.worldX, convertedPlayer.worldY)));

            // Entering new group
            PlayersList.players[convertedPlayer.getId()] = convertedPlayer;
            await Groups.AddToGroupAsync(Context.ConnectionId, convertedPlayer.GetGroupId());
            await Clients.Group(convertedPlayer.GetGroupId()).SendAsync("RecieveInfoAboutOtherPlayers", JsonConvert.SerializeObject(World.Instance.GetPlayers(convertedPlayer.worldX, convertedPlayer.worldY)));
        }

        public async Task UpdatePlayerInfo(string player)
        {
            var convertedPlayer = JsonConvert.DeserializeObject<Player>(player);


            if (convertedPlayer.x <= World.transitionOffset)
            {
                if (convertedPlayer.worldX > 0)
                {
                    await MovePlayer(convertedPlayer, -1 , 0, 700, convertedPlayer.y);
                }
            }
            else if (convertedPlayer.x >= World.canvasWidth - World.transitionOffset)
            {
                if (convertedPlayer.worldX < World.width-1)
                {
                    await MovePlayer(convertedPlayer, 1 , 0, 100, convertedPlayer.y);
                }
            }
            else if (convertedPlayer.y <= World.transitionOffset)
            {
                if (convertedPlayer.worldY > 0)
                {
                    await MovePlayer(convertedPlayer, 0, -1, convertedPlayer.x, 400);
                }
            }
            else if (convertedPlayer.y >= World.canvasHeight - World.transitionOffset)
            {
                if (convertedPlayer.worldY < World.height-1)
                {
                    await MovePlayer(convertedPlayer, 0, 1, convertedPlayer.x, 100);
                }
            }

            PlayersList.players[convertedPlayer.getId()] = convertedPlayer;
            World.Instance.UpdatePlayer(convertedPlayer);
            await Clients.Group(convertedPlayer.GetGroupId()).SendAsync("RecieveInfoAboutOtherPlayers", JsonConvert.SerializeObject(World.Instance.GetPlayers(convertedPlayer.worldX, convertedPlayer.worldY)));
        }

        public async Task HandleClientRequest(string data)
        {
            await Task.Run(()=>{ ServerEngine.NetworkManager.HandleClientRequest(data);});
        }
        //to do: handle player disconnect
        //to do: handle player reconnect

    }
}