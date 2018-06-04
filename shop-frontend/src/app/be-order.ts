import { ItemQuantity } from './item-quantity';

export class BeOrder {
    DeliveryAddress: string;
    OrderStatus: string;
    Price: number;
    ItemQuantities: ItemQuantity[];
}
