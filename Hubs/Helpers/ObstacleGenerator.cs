using SignalRWebPack.Obstacles;
using System;

namespace SignalRWebPack.Managers {
  static class RandomObstacle {
    public static Obstacle GenerateObstacle(int x, int y) {
      var obstacleCreator = new ObstacleCreator();
      var rand = new Random();
      var obstacleTypeIndex = rand.Next(2);
      int obstacleSubtypeIndex = rand.Next(2);
      ObstacleType obstacleType;
      string obstacleSubtype;
      switch(obstacleTypeIndex) {
        case 0: {
          obstacleType = ObstacleType.Impassable;
          break; 
        }
        default: {
          obstacleType = ObstacleType.Passable;
          break;
        }
      }
      if(obstacleType == ObstacleType.Passable) {
        switch(obstacleSubtypeIndex) {
          case 0 or 1: {
            obstacleSubtype = "bush";
            break; 
          }
          default: {
            obstacleSubtype = "cactus";
            break;
          }
        }
      } else {
        switch(obstacleSubtypeIndex) {
          case 0: {
            obstacleSubtype = "rocks1";
            break; 
          }
          default: {
            obstacleSubtype = "tree1";
            break;
          }
        }
      }
      var obstacle = obstacleCreator.FactoryMethod(obstacleType, obstacleSubtype, $"{x},{y}");
      return obstacle;
    }
  }
}

