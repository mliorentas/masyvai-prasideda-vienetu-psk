import { Component, OnInit, Input } from '@angular/core';
import { Item } from '../item';
import { Order } from '../order';
import { Attribute } from '../attribute';
import { UserService } from '../user.service';
import { UserRole } from '../user-role.enum';
import { OrderService } from '../order.service';
import { BeFullOrder } from '../be-full-order';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import { OrderStatus } from '../order-status.enum';

@Component({
  selector: 'app-order-edit',
  templateUrl: './order-edit.component.html',
  styleUrls: ['./order-edit.component.css']
})
export class OrderEditComponent implements OnInit {
  @Input()
  order: BeFullOrder;
  constructor(
    private userService: UserService,
    private orderService: OrderService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit() {
  }
  newStatus: string;

  updateStatus(newStatus:string, order:BeFullOrder): void {
    order.OrderStatus = newStatus;
    this.orderService.updateOrder(order).subscribe(r => {
      console.log(r);
      order = r.body;
    });;
  }

  payOrder(order: BeFullOrder): void {
    this.orderService.orderToPay = order;
    this.router.navigateByUrl('/payment');    
  }

  isPaid(order: BeFullOrder): boolean {
    return order.OrderStatus === OrderStatus.Paid;
  }
}
