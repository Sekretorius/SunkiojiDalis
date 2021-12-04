import { Item } from '../Item';

export abstract class AbstractConsumable extends Item {
  constructor(guid: string, itemData: any, imageSharedData: any) {
    super(guid, itemData, imageSharedData);
  }

  public Consume(): number{
    return 0;
  }
}


