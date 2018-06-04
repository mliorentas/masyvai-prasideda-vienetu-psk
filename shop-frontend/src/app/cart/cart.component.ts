import { Component, OnInit } from '@angular/core';
import { CartService } from '../cart.service';
import { Cart } from '../cart';
import { Router } from '@angular/router';
import { UserService } from '../user.service';
import { AlertService } from '../alert.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  constructor(
    public cartService:CartService,
    private userService: UserService,
    private router: Router,
    private alertService: AlertService
  ) { }

  ngOnInit() {
  }

  public continue(): void {
    if (this.userService.loggedIn) {
      this.router.navigateByUrl('/order');
    } else {
      this.alertService.error("Prieš perkant prašome prisijungti.", true);
      this.router.navigateByUrl('/log-in');
    }   
  }
}
