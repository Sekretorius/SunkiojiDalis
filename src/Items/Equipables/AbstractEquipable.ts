import { Item } from '../Item';

export abstract class AbstractEquipable extends Item {
  constructor(guid: string, itemData: any, imageSharedData: any) {
    super(guid, itemData, imageSharedData);
  }

  public Equip(): number {
    return 0;
  }
  public Unequip(): number {
    return 0;
  }
}


