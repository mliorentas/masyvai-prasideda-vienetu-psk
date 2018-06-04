import { Pipe, PipeTransform } from '@angular/core';
import { User } from './user';
import { Item } from './item';
import { Order } from './order';
import { BeFullOrder } from './be-full-order'

@Pipe({
  name: 'userSearchFilter'
})
export class UserFilterPipe implements PipeTransform {
  transform(items: User[], searchText: string): User[] {
    if (!items) return [];
    if (!searchText) return items;
    searchText = searchText.toLowerCase();
    return items.filter(it => {
      return it.FirstName.toLowerCase().includes(searchText) || it.SecondName.toLowerCase().includes(searchText) || it.Email.toLowerCase().includes(searchText)|| it.PhoneNumber.toLowerCase().includes(searchText);
    });
  }
}

@Pipe({
  name: 'orderSearchFilter'
})
export class OrderFilterPipe implements PipeTransform {
  transform(items: BeFullOrder[], searchText: string): BeFullOrder[] {
    if (!items) return [];
    if (!searchText) return items;
    searchText = searchText.toLowerCase();
    return items.filter(it => {
      return it.Id.toString().includes(searchText)
       || it.OrderStatus.toLowerCase().includes(searchText)
        || it.DeliveryAddress.toLowerCase().includes(searchText)
        || it.User.FirstName.toLowerCase().includes(searchText)
        || it.User.Email.toLowerCase().includes(searchText)
        || it.User.SecondName.toLowerCase().includes(searchText)
    });
  }
}

@Pipe({
  name: 'itemSearchFilter'
})
export class ItemFilterPipe implements PipeTransform {
  transform(items: Item[], searchText: string): Item[] {
    if (!items) return [];
    if (!searchText) return items;
    searchText = searchText.toLowerCase();
    return items.filter(it => {
      return it.SkuCode.toString().includes(searchText) || it.Name.toLowerCase().includes(searchText) || it.Description.toLowerCase().includes(searchText) || it.Categories.some(cat => cat.Name.includes(searchText));
    });
  }
}