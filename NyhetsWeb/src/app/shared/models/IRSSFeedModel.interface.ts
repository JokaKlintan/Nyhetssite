import { IRSSFeedItemModel } from './IRSSFeedItemModel.interface';
import { IRSSFeedSourceModel } from './IRSSFeedSourceModel.interface';

export interface IRSSFeedModel {
  Source: IRSSFeedSourceModel;
  Items: IRSSFeedItemModel[];
}
