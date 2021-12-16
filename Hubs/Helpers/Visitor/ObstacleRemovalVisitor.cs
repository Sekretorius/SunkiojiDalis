using System;
using System.Collections.Generic;
using SignalRWebPack.Hubs.Worlds;
using SignalRWebPack.Obstacles;

namespace SignalRWebPack.Managers
{
    class ObstacleRemovalVisitor : IVisitor
    {
        public void VisitDesertArea(DesertArea element)
        {
            var obstacles = World.Instance.GetObstacles(element.x, element.y);
            var badObstacles = new List<Obstacle>();
            foreach(var obstacle in obstacles) {
                if(obstacle.Sprite.Contains("tree")) {
                    badObstacles.Add(obstacle);
                }
            }
            foreach(var obstacle in badObstacles) {
                World.Instance.RemoveObstacle(obstacle);
                Console.WriteLine("Removed tree from the desert!");
            }
        }

        public void VisitForestArea(ForestArea element)
        {
            var obstacles = World.Instance.GetObstacles(element.x, element.y);
            var badObstacles = new List<Obstacle>();
            foreach(var obstacle in obstacles) {
                if(obstacle.Sprite.Contains("cactus")) {
                    badObstacles.Add(obstacle);
                }
            }
            foreach(var obstacle in badObstacles) {
                World.Instance.RemoveObstacle(obstacle);
                Console.WriteLine("Removed cactus from the forest!");
            }
        }
    }
}