import { ImageRenderer } from '../Helpers/ImageComponent';
import { ImageSharedData } from '../Helpers/ImageData';
import { Vector2D } from '../Helpers/Vector2D';
import { DestroyObject } from '../Managers/ClientEngine';

export class Character
{
    guid: string;
    name: string;
    health: number;
    //sprite: string;
    areaId: string;
    position: any;
    //width: number;
    //height: number;
    //frameX: number;
    //frameY: number;
    speed: number;
    targetPosition: any;
    originPosition: any;
    travelTime: number;
    elapsedTime: number;

    imageRenderer: any;

    constructor(guid: string, characterData: any, imageSharedData: any)
    {
        this.guid = guid;
        this.name = characterData.name;
        this.health = parseFloat(characterData.health);

        this.areaId = characterData.areaId;
        this.position = new Vector2D(parseFloat(characterData.x), parseFloat(characterData.y));
        
        
        this.imageRenderer = new ImageRenderer(imageSharedData, 
            parseInt(characterData.frameX),
            parseInt(characterData.frameY),
            this.position);

        //this.sprite = characterData.sprite;
        //this.width = parseInt(characterData.width);
        //this.height = parseInt(characterData.height);
        //this.frameX = parseInt(characterData.frameX);
        //this.frameY = parseInt(characterData.frameY);
        this.speed = parseFloat(characterData.speed);

        this.targetPosition = new Vector2D(parseFloat(characterData.x), parseFloat(characterData.y));
        this.originPosition = new Vector2D(parseFloat(characterData.x), parseFloat(characterData.y));
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
        DestroyObject(this.guid);
    }
}