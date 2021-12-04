import { AbstractWeapon } from '../AbstractWeapon';

export class CommonWeapon extends AbstractWeapon {

  constructor(guid: string, itemData: any, imageSharedData: any) {
    super(guid, itemData, imageSharedData);
  }
}