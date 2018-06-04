import { Component, OnInit } from '@angular/core';
import { Item } from '../item';
import { Category } from '../Category';
import { ItemsService } from '../items.service';
import { CartService } from '../cart.service';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../user.service';

@Component({
  selector: 'app-item-list',
  templateUrl: './item-list.component.html',
  styleUrls: ['./item-list.component.css']
})
export class ItemListComponent implements OnInit {

  categories: Category[];
  attributes: string[];

  items: Item[];
  searchText: string;
  constructor(private itemsService: ItemsService, private cartService: CartService, private route: ActivatedRoute, public userService: UserService
  ) {
    this.searchText = this.route.snapshot.paramMap.get('search');
    // if (this.searchText != null)
    //   this.searchItems(this.searchText);
    // else
      this.getItems();
    this.getCategories();


    console.log(this.searchText);
  }

  ngOnInit() {
  }
  getItems(): void {
    this.itemsService.getItems()
      .subscribe(items => {
        console.log(items);
        this.items = items
      });
  }

  addItem(): void {
    console.log("Add item function");
  }

  getCategories() {
    this.itemsService.getCategories().subscribe(categories => {
      console.log(categories);
      this.categories = categories
    });
  }
  searchItems(search: string) {
    this.itemsService.searchItems(search)
    .subscribe(items => {
      console.log(items);
      this.items = items
    });
  }
}
