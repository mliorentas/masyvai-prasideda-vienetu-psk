import { BeItem } from './/be-item';
import { User } from './/user';

export class BeFullOrder {
  Id: number;
  OrderStatus: string;
  TotalPrice: number;
  DeliveryAddress: string;
  ItemsQty: string;
  User: User;
  Items: BeItem[];
}
