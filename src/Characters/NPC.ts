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
        this.Position.X = this.TargetPosition.X;
        this.Position.Y = this.TargetPosition.Y;
        this.TargetPosition = new Vector2D(parseFloat(syncData.RequestData.x), parseFloat(syncData.RequestData.y)); 
    }
}