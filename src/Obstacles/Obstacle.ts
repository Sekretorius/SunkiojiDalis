import { ImageRenderer } from "../Helpers/ImageComponent";
import { Vector2D } from "../Helpers/Vector2D";

export abstract class Obstacle {
  
  public guid: string;
  public Id: number;
  public Position: Vector2D;

  public ImageRenderer: any;

  constructor(guid: string, itemData: any, imageSharedData: any) {
    this.guid = guid;
    this.Id = itemData.id;
    this.Position = new Vector2D(parseFloat(itemData.x), parseFloat(itemData.y));
    this.ImageRenderer = new ImageRenderer(imageSharedData, 0, 0, this.Position);
  }
  
  public getId(): number {
    return this.Id;
  }
}