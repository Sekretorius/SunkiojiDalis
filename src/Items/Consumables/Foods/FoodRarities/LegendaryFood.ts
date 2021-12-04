import { AbstractFood } from '../AbstractFood';

export class LegendaryFood extends AbstractFood {
  constructor(guid: string, itemData: any, imageSharedData: any) {
    super(guid, itemData, imageSharedData);
  }
}