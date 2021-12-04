import { AbstractWeapon } from '../AbstractWeapon';

export class LegendaryWeapon extends AbstractWeapon {
  constructor(guid: string, itemData: any, imageSharedData: any) {
    super(guid, itemData, imageSharedData);
  }
}