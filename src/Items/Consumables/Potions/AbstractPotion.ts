import { AbstractConsumable } from '../AbstractConsumable';

export abstract class AbstractPotion extends AbstractConsumable {
  public Ability: string;

  constructor(guid: string, itemData: any, imageSharedData: any) {
    super(guid, itemData, imageSharedData);
    this.Ability = itemData.ability;
  }
}


