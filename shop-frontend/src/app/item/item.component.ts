import { Component, OnInit, Input } from '@angular/core';
import { BeItem } from '../be-item';
import { CartService } from '../cart.service';
import { ItemsService } from '../items.service';
import { UserService } from '../user.service';

@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.css']
})
export class ItemComponent implements OnInit {
  @Input()
  item: BeItem;
  constructor(private cartService:CartService, public itemService:ItemsService, public userService: UserService) { ;
  }

  errorMessage = 'Įvyko klaida';

  ngOnInit() {
  }
  
  addItem(item : BeItem): void{
    console.log("add item component");
    console.log(item)
    this.cartService.addItem(item);
  }
  removeItem(item : BeItem): void{
    // console.log(item)
    // this.cartService.addItem(item);
  }
  deleteItem (item: BeItem) : void {
    console.log(item);
    this.itemService.deleteItem(item.Id).subscribe(
      result => console.log(result),
      error => this.errorMessage = error);
  }

  editItem(item: BeItem) : void {
    console.log(item);
  }
}
