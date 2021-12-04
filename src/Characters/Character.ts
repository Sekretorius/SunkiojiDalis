import { ImageRenderer } from '../Helpers/ImageComponent';
import { ImageSharedData } from '../Helpers/ImageData';
import { Vector2D } from '../Helpers/Vector2D';
import { DestroyObject } from '../Managers/ClientEngine';

export class Character
{
    public Guid: string;
    public Name: string;
    public Health: number;
    public AreaId: string;
    public Position: any;
    public Speed: number;
    public TargetPosition: any;
    public OriginPosition: any;
    public TravelTime: number;
    public ElapsedTime: number;

    ImageRenderer: any;

    constructor(guid: string, characterData: any, imageSharedData: any)
    {
        this.Guid = guid;
        this.Name = characterData.name;
        this.Health = parseFloat(characterData.health);

        this.AreaId = characterData.areaId;
        this.Position = new Vector2D(parseFloat(characterData.x), parseFloat(characterData.y));
        
        this.ImageRenderer = new ImageRenderer(imageSharedData, 
            parseInt(characterData.frameX),
            parseInt(characterData.frameY),
            this.Position);

        this.Speed = parseFloat(characterData.speed);

        this.TargetPosition = new Vector2D(parseFloat(characterData.x), parseFloat(characterData.y));
        this.OriginPosition = new Vector2D(parseFloat(characterData.x), parseFloat(characterData.y));
    }

    GetAttackAlgorithm(){
        //maybe use this for visual showing
    }

    GetMoveAlgorithm(){
        //maybe use this for visual showing
    }

    Attack(){

    }

    Move(){

    }

    Die(){

    }

    Destroy(data: string)
    {
        DestroyObject(this.Guid);
    }
}