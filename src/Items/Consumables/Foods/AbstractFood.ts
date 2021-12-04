import { AbstractConsumable } from '../AbstractConsumable';

export abstract class AbstractFood extends AbstractConsumable {
  public Health: number;

  constructor(guid: string, itemData: any, imageSharedData: any) {
    super(guid, itemData, imageSharedData);
    this.Health = itemData.health;
  }
}


