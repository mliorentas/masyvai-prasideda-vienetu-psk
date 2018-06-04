import { Category } from "./category";
import { Attribute } from "./attribute";

export class Item {
    Id: number;
    Name : string;
    Description : string;
    SkuCode : string;
    Discount: number;
    Price: number;
    IsDisabled : boolean;
    DiscountPrice : number;
    Categories : Category[];
    Property : Attribute;
    Images: {Id:number, ImageUrl: string}[];
}