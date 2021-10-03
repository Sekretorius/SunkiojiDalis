using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Linq;

namespace SunkiojiDalis.Hubs
{
    [JsonObject(MemberSerialization.Fields)]
    public class Player {
        private int id;
        private int x;
        private int y;
        private int width;
        private int height;
        private int frameX;
        private int frameY;
        private int speed;
        private bool moving;
        private string sprite;

        public Player(int id, int x, int y, int width, int height, int frameX, int frameY, int speed, bool moving, string sprite) {
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
            //to do: sync other actions 
        }

        public void setId(int id) {
            this.id = id;
        }

        public int getId() {
            return this.id;
        }
    }

    public static class PlayersList {
        public static Dictionary<int, Player> players = new Dictionary<int, Player>();
    }

    public static class ItemsList {
        public static Dictionary<int, Item> items = new Dictionary<int, Item>();
        
        public static Item GenerateItem() {
            Random rd = new Random();
            int randNum = rd.Next(1, 9);
            int randomItemId = rd.Next(1, 99999);
            AbstractItemFactory factory;
            if(randNum > 7) {
                factory = new LegendaryItemFactory();
            } else {
                factory = new CommonItemFactory();
            }
            string spritePath = "";
            GenerateRandomItemAttributes(out int id, 
                                         out string name,
                                         out int weight,
                                         out int quantity,
                                         out int x,
                                         out int y);
            switch(randNum) {
                case 1 or 2:
                    spritePath = PickRandomItemSprite("resources/items/armor/armor");
                    return factory.CreateArmor(id, spritePath, name, weight, quantity, x, y, rd.Next(1,11));
                case 3 or 4:
                    spritePath = PickRandomItemSprite("resources/items/weapon/weapon");
                    return factory.CreateWeapon(id, spritePath, name, weight, quantity, x, y, rd.Next(1,11));
                case 5 or 6:
                    spritePath = PickRandomItemSprite("resources/items/weapon/weapon");
                    return factory.CreateFood(id, spritePath, name, weight, quantity, x, y, rd.Next(1,101));
                case 7 or 8:
                    spritePath = PickRandomItemSprite("resources/items/weapon/weapon");
                    return factory.CreatePotion(id, spritePath, name, weight, quantity, x, y, "Useless ability");
                default:
                    break;
            }
            var nullItem = factory.CreateArmor(-1, spritePath, "", -1, -1, -1, -1, -1);
            return nullItem;
        }

        public static void GenerateRandomItemAttributes(out int id, out string name, out int weight, out int quantity, out int x, out int y) {
            Random rd = new Random();
            id = rd.Next(1, 99999);
            while(items.ContainsKey(id)) {
                id = rd.Next(1, 99999);
            }
            name = "item_" + id.ToString();
            weight = rd.Next(1, 11);
            quantity = rd.Next(1,4);
            x = rd.Next(20, 780);
            y = rd.Next(20, 480);
        }

        public static string PickRandomItemSprite(string prefix) {
            Random rd = new Random();
            string filename = prefix + (rd.Next(0, 10)).ToString() + ".png";
            return filename;
        }
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
            await Clients.All.SendAsync("RecieveInfoAboutOtherPlayers", Newtonsoft.Json.JsonConvert.SerializeObject(PlayersList.players.Values.ToList()));
        }

        public async Task UpdatePlayerInfo(string player)
        {
            var convertedPlayer = Newtonsoft.Json.JsonConvert.DeserializeObject<Player>(player);
            PlayersList.players[convertedPlayer.getId()] = convertedPlayer;
            await Clients.All.SendAsync("RecieveInfoAboutOtherPlayers", Newtonsoft.Json.JsonConvert.SerializeObject(PlayersList.players.Values.ToList()));
        }

        //to do: handle player disconnect
        //to do: handle player reconnect

    }
}