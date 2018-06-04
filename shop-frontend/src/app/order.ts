import { Item } from './/item';
import { User } from './/user';

export class Order {
    id: number;
    status : string;
    paymentStatus : string;
    price : number;
    items : Item[];
    buyer : User;
} 