import { Component, OnInit } from '@angular/core';
import {User} from '../user';
import {UserService} from '../user.service';
import { Router } from '@angular/router';
import {AlertService} from '../alert.service';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  signinResult = "";
  user: User = new User();

  constructor(
    private userService: UserService,
    private router: Router,
    private alertService: AlertService
  ) { 
  }

  ngOnInit() {
  }

  createUser() {
    this.user.IsBanned = false;
    console.log(this.user);
    this.userService.postUser(this.user).subscribe(user => {
      this.user = user;
      this.alertService.success('Paskyra sukurta', true); 
      this.router.navigate(['/log-in']);
    },
    error => {
      this.alertService.error('Klaida bandant sukurti paskyrą', true); 
    });
  }
}
