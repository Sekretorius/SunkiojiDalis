import { AbstractFood } from '../AbstractFood';

export class CommonFood extends AbstractFood {
  constructor(guid: string, itemData: any, imageSharedData: any) {
    super(guid, itemData, imageSharedData);
  }
}