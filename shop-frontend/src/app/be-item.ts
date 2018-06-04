import { Image } from './image'
import { Category } from './category'
import { Property } from './property'
export class BeItem {
    Id: number;
    Name : string;
    Description : string;
    SkuCode : string;
    Discount: number;
    Price: number;
    IsDisabled: boolean;
    DiscountedPrice: number;
    Images: Image[];
    Categories: Category[];
    Property: Property;
}