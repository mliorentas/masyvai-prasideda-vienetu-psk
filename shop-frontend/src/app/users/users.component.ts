import { Component, OnInit } from '@angular/core';
import { User } from '../user';
import { UserService } from '../user.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  users: User[];

  constructor(private userService: UserService) {
    this.getUsers();
  }

  ngOnInit() {
  }

  getUsers() : void{
    this.userService.getUsers().subscribe(users => {console.log(users);this.users = users});
  }

  banUser(user) {
    this.userService.banUser(user.Id).subscribe(r => { user.IsBanned = r.IsBanned });
  }

  unbanUser(user) {
    this.userService.unbanUser(user.Id).subscribe(r => { user.IsBanned = r.IsBanned });
  }
}
