import { ImageRenderer } from "../Helpers/ImageComponent";
import { Vector2D } from "../Helpers/Vector2D";
import { DestroyObject } from "../Managers/ClientEngine";

export class Projectile
{
    public Guid: string;
    public AreaId: number;
    public Position: Vector2D;
    
    public Width: number;
    public Height: number;
    
    public Speed: number;
    public TargetPosition: Vector2D;
    public OriginPosition: Vector2D;

    public ImageRenderer: any;

    constructor(guid: string, projectileData: any, imageSharedData: any)
    {
        this.Guid = guid;
        this.Position = new Vector2D(parseFloat(projectileData.x), parseFloat(projectileData.y));

        this.Width = parseInt(projectileData.width);
        this.Height = parseInt(projectileData.height);

        this.Speed = parseFloat(projectileData.speed);

        this.TargetPosition = new Vector2D(parseFloat(projectileData.x), parseFloat(projectileData.y));
        this.OriginPosition = new Vector2D(parseFloat(projectileData.x), parseFloat(projectileData.y));

        this.ImageRenderer = new ImageRenderer(imageSharedData, 0, 0, this.Position);
    }

    SyncPosition(syncData)
    {
        this.Position.X = this.TargetPosition.X;
        this.Position.Y = this.TargetPosition.Y;
        this.TargetPosition = new Vector2D(parseFloat(syncData.RequestData.x), parseFloat(syncData.RequestData.y)); 
    }

    Destroy(data: string)
    {
        DestroyObject(this.Guid);
    }
}