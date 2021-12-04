import { Obstacle } from './Obstacle';

export class PassableObstacle extends Obstacle {
  public Type: string;

  constructor(guid: string, characterData: any, imageSharedData: any) {
    super(guid, characterData, imageSharedData);
    this.Type = characterData.type;
  }
}