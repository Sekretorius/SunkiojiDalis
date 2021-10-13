using SunkiojiDalis.Hubs.World;
using System.Collections.Generic;
using System.Linq;

namespace SunkiojiDalis.Hubs.Managers
{
    public class WorldManager
    {
        public const int width = 5;
        public const int height = 5;

        private static WorldManager instance;
        public static WorldManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WorldManager();
                }
                return instance;
            }
            set { if (instance == null) instance = value; }
        }

        private Area[,] world = new Area[width, height];

        public WorldManager()
        {
            for (int i = 0; i < world.GetLength(0); i++)
                for (int t = 0; t < world.GetLength(1); t++)
                    world[i, t] = new Area(i, t);
        }

        public List<Player> GetPlayers(int x, int y)
        {
            return world[x, y].players.Values.ToList();
        }

        public void AddPlayer(Player player)
        {
            world[player.worldX, player.worldY].AddPlayer(player);
        }

        public void RemovePlayer(Player player)
        {
            world[player.worldX, player.worldY].RemovePlayer(player);
        }

        public void UpdatePlayer(Player player)
        {
            world[player.worldX, player.worldY].UpdatePlayer(player);
        }
    } 
}