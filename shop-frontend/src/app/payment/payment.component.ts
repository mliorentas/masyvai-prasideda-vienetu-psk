import { Component, OnInit } from '@angular/core';
import { Payment } from '../payment';
import { CartService } from '../cart.service';
import { UserService } from '../user.service';
import { PaymentService } from '../payment.service';
import { AlertService } from '../alert.service';
import { Router } from '@angular/router';
import { OrderService } from '../order.service';
import { OrderStatus } from '../order-status.enum';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {

  payment: Payment;

  constructor(
    private cartService: CartService,
    private userService: UserService,
    private paymentService: PaymentService,
    private alertService: AlertService,
    private router: Router,
    private orderService: OrderService
  ) { }

  ngOnInit() {
    this.payment = new Payment();
    this.payment.amount = this.orderService.orderToPay.TotalPrice;
    this.payment.holder = this.userService.currentUser.FirstName + " " + this.userService.currentUser.SecondName;
  }

  performPayment() {
    this.paymentService.addPayment(this.payment).subscribe(r => {
      console.log(r);
      if (r.status === 201) {
        this.alertService.success("Mokėjimas atliktas", true);
        this.updateOrderStatus();
        this.router.navigateByUrl('/home');
      } else {
        this.alertService.error("Klaida bandant atlikti mokėjimą");
      }
    },
    error => {
      this.alertService.error("Klaida bandant atlikti mokėjimą"); 
      throw error;
    });
  }

  updateOrderStatus() {
    this.orderService.orderToPay.OrderStatus = OrderStatus.Paid;
    this.orderService.updateOrder(this.orderService.orderToPay).subscribe(r => {
      console.log(r);
    },
    error => {
      throw error;
    });
  }
}
