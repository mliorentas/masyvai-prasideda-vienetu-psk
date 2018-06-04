import { Component, OnInit, Input } from '@angular/core';
import { CartService } from '../cart.service';
import { SessionService } from '../session.service';
import { UserService } from '../user.service';
import { AlertService } from '../alert.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  
  
  constructor(public cartService: CartService,
    private sessionService: SessionService,
    public userService: UserService,
    private alertService: AlertService,
    private router: Router
  ) { 
  }
  
  ngOnInit() {
    }

  logout()
  {
    this.sessionService.logOut().subscribe(response => { 
      if (response.status === 200) {
        this.alertService.success("Sėkmingai atsijungėte", true);
        this.userService.getUserRole();
        this.userService.setUserLogin(false);
        this.router.navigateByUrl('/log-in');   
      } else {
        this.alertService.error("Atsijungiant įvyko klaida");
      }
     }, 
      err => {
      this.alertService.error("Atsijungiant įvyko klaida");
      throw err;
    });
  }

  search(searchText) {
    window.location.reload();
    this.router.navigate(['/home/'+searchText]);   
  }

}
