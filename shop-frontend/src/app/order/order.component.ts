import { Component, OnInit } from '@angular/core';
import { CartService } from '../cart.service';
import { OrderService } from '../order.service';
import { BeOrder } from '../be-order';
import { OrderStatus } from '../order-status.enum';
import { AlertService } from '../alert.service';
import { Router } from '@angular/router';
import { UserService } from '../user.service'

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {

  order: BeOrder;
  city: string;
  street: string;
  houseNumber: string;
  zip: string;

  constructor(
    private cartService: CartService,
    private orderService: OrderService,
    private alertService: AlertService,
    private router: Router,
    private userService: UserService
  ) { }

  ngOnInit() {
    this.order = new BeOrder();
    this.order.ItemQuantities = this.cartService.getItemQuantity();
    this.order.OrderStatus = OrderStatus.NotPaid;
    this.order.Price = this.cartService.cart.price;
    this.city = this.userService.currentUser.City;
    this.street = this.userService.currentUser.Street;
    this.houseNumber = this.userService.currentUser.HouseNumber;
    this.zip = this.userService.currentUser.Zip;
  }

  registerOrder() {
    this.order.DeliveryAddress = this.city + ', ' + this.street + ' ' + this.houseNumber + ', ' + this.zip;
    this.orderService.addOrder(this.order).subscribe(r => {
      console.log(r);
      if (r.status === 200) {
        this.alertService.success("Užsakymas suformuotas", true); 
        this.orderService.orderToPay = r.body;
        this.cartService.clearCart();
        this.router.navigateByUrl('/payment');
      } else {
        this.alertService.error("Klaida bandant suformuoti užsakymą");
      }
    },
    error => {
      this.alertService.error("Klaida bandant suformuoti užsakymą"); 
      throw error;
    });
  }
}
