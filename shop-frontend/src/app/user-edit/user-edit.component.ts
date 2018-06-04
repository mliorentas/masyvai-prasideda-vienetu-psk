import { Component, OnInit } from '@angular/core';
import { User } from '../user';
import { UserService } from '../user.service';
import {AlertService} from '../alert.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.css']
})
export class UserEditComponent implements OnInit {
  user: User;
  editResult = "";

  constructor(
    private userService: UserService,
    private alertService: AlertService,
    private router: Router,

  ) {
    this.getUser();
  }

  getUser() {
    this.userService.getCurrentUser().subscribe(
      user => {
        this.user = user;
      });
  }

  ngOnInit() {
  }

  updateUser() {
    this.userService.updateUser(this.user).subscribe(
      user => {
        this.user = user;
        this.alertService.success("Duomenys išsaugoti", true); 
        this.router.navigate([]);
        window.scrollTo(0,0);
      },
      error => {
        this.alertService.error("Klaida bandant pakeisti duomenis"); 
      });
  }
}
