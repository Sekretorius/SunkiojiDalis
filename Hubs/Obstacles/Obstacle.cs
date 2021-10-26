namespace SignalRWebPack.Obstacles
{
  public abstract class Obstacle {
    public int Id;
    public string Sprite;
    public int X;
    public int Y;
    public Obstacle(int Id, string Sprite, int X, int Y) {
      this.Id = Id;
      this.Sprite = Sprite;
      this.X = X;
      this.Y = Y;
    }

    public int getId() {
      return this.Id;
    }
  }

  public enum ObstacleType {
    Passable,
    Impassable
  }
}