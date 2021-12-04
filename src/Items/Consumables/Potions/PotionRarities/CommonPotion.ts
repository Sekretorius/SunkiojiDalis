import { AbstractPotion } from '../AbstractPotion';

export class CommonPotion extends AbstractPotion {
  constructor(guid: string, itemData: any, imageSharedData: any) {
    super(guid, itemData, imageSharedData);
  }
}
