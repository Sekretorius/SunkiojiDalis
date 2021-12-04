import { AbstractEquipable } from '../AbstractEquipable';

export abstract class AbstractWeapon extends AbstractEquipable {
  public Damage: number;
  constructor(guid: string, itemData: any, imageSharedData: any) {
    super(guid, itemData, imageSharedData);
    this.Damage = itemData.damage;
  }
}

