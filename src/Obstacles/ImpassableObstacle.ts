import { Obstacle } from './Obstacle';

export class ImpassableObstacle extends Obstacle {
  public Effect: string;

  constructor(guid: string, characterData: any, imageSharedData: any) {
    super(guid, characterData, imageSharedData);
    this.Effect = characterData.effect;
  }
}