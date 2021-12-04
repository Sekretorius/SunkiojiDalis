import { Character } from './Character';
import { Vector2D } from '../Helpers/Vector2D';
import { CalculateTravelTime } from '../Managers/ClientEngine';
import { ImageSharedData } from '../Helpers/ImageData';

export class NPC extends Character
{
    constructor(guid: string, characterData: any, imageSharedData: any)
    {
        super(guid, characterData, imageSharedData);
    }

    SetAttackAlgorithm(){
        //maybe use this for visual showing
    }

    SetMoveAlgorithm(){
        //maybe use this for visual showing
    }

    Attack(){

    }

    Move(){

    }

    Die(){

    }
    
    SyncPosition(syncData)
    {
        this.position.x = this.targetPosition.x;
        this.position.y = this.targetPosition.y;
        this.targetPosition = new Vector2D(parseFloat(syncData.RequestData.x), parseFloat(syncData.RequestData.y)); 

        //this.originPosition = new Vector2D(this.position.x, this.position.y);

        //this.elapsedTime = 0;
        //this.travelTime = CalculateTravelTime(this.originPosition, this.targetPosition, this.speed);
    }
}