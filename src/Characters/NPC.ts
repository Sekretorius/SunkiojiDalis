import { Character } from './Character';
import { Vector2D } from '../Managers/Vector2D';
import { CalculateTravelTime } from '../Managers/ClientEngine';

export class NPC extends Character
{
    constructor(guid: string, characterData: any)
    {
        super(guid, characterData);
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
        let newX = parseFloat(syncData.RequestData.x);
        let newY = parseFloat(syncData.RequestData.y);

        this.position = new Vector2D(this.targetPosition.x, this.targetPosition.y);
        this.targetPosition = new Vector2D(newX, newY); 

        this.originPosition = new Vector2D(this.position.x, this.position.y);

        this.elapsedTime = 0;
        this.travelTime = CalculateTravelTime(this.originPosition, this.targetPosition, this.speed);
    }
}