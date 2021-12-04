import { ImageRenderer } from "../Helpers/ImageComponent";
import { Vector2D } from "../Helpers/Vector2D";

export abstract class Item {
  public Guid: string;
  public Id: number;
  public Name: string;
  public Weight: number;
  public Quantity: number;
  public Position: Vector2D;
  public BelongsTo: number;
  public ImageRenderer: any;

  constructor(guid: string, itemData: any, imageSharedData: any) {
    this.Guid = guid;
    this.Id = itemData.id;
    this.Name = itemData.name;
    this.Weight = itemData.weight;
    this.Quantity = itemData.quantity;
    this.BelongsTo = itemData.belongsTo;

    this.Position = new Vector2D(parseFloat(itemData.x), parseFloat(itemData.y));
    this.ImageRenderer = new ImageRenderer(imageSharedData, 0, 0, this.Position);
  }
}