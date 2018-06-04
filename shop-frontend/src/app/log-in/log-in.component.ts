import { Component, OnInit } from '@angular/core';
import { SessionService } from '../session.service';
import { User } from '..//user';
import { AlertService } from '../alert.service';
import { Router } from '@angular/router';
import { UserService } from '../user.service';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent implements OnInit {

  success = "";
  user: User = new User();

  constructor(
    private sessionService: SessionService,
    private alertService: AlertService,
    private router: Router,
    private userService: UserService
  ) { }

  ngOnInit() {
  }

  logIn() {
    console.log(this.user);
    this.sessionService.logIn(this.user).subscribe(r => {
      console.log(r);
      if (r.status === 200) {
        this.alertService.success("Sėkmingai prisijungėte", true);
        this.userService.getUserRole();
        this.userService.setUserLogin(true);        
        // this.router.navigate(["/home"]);
        this.router.navigateByUrl('/home');
      } else {
        this.alertService.error("Prisijungti nepavyko");
      }
    },
      err => {
        this.alertService.error("Prisijungti nepavyko");
        throw err;
      });
  }
}
