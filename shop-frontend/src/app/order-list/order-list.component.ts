import { Component, OnInit } from '@angular/core';
import { Item } from '../item';
import { Order } from '../order';
import { Attribute } from '../attribute';
import { UserService } from '../user.service'
import { UserRole } from '../user-role.enum'
import { OrderService } from '../order.service'
import { BeFullOrder } from '../be-full-order'

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrderListComponent implements OnInit {
  orders: BeFullOrder[] //= [{ id: 13546, status: "Naujas", buyer: null, paymentStatus: "Apmokėtas", price: 212, items: [{ id: 1, Name: "Kaistuvas AC-2005", Description: "Geras ir karštas lygintuvas", Price: 11.45, Property_Id: 1, Discount: 0, SkuCode: "Kodas", Photos: [""] }] }];
  constructor(
    private userService: UserService,
    private orderService: OrderService
  ) { }
  newStatus: string;
  editOrders: BeFullOrder //= [{ id: 13546, status: "Naujas", buyer: null, paymentStatus: "Apmokėtas", price: 212, items: [{ id: 1, Name: "Kaistuvas AC-2005", Description: "Geras ir karštas lygintuvas", Price: 11.45, Property_Id: 1, Discount: 0, SkuCode: "Kodas", Photos: [""] }] }];

  ngOnInit() {
    if (this.userService.currentUser.UserRole === UserRole.Admin) {
      this.orderService.getAllOrders().subscribe(r => {
        console.log(r);
        this.orders = r;
      });
    } else {
      this.orderService.getUserOrders().subscribe(r => {
        console.log(r);
        this.orders = r;
      });
    }
  }

}
