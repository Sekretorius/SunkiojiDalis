import { AbstractEquipable } from '../AbstractEquipable';

export abstract class AbstractArmor extends AbstractEquipable {
  public Defense: number;
  constructor(guid: string, itemData: any, imageSharedData: any) {
    super(guid, itemData, imageSharedData);
    this.Defense = itemData.defense;
  }
}


