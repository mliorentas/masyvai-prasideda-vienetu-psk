import { Component, OnInit } from '@angular/core';
import { ItemsService } from '../items.service';
import { Item } from '../item';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { Category } from '../category';
import { Attribute } from '../attribute';
import { BeItem } from '../be-item';

@Component({
  selector: 'app-item-edit',
  templateUrl: './item-edit.component.html',
  styleUrls: ['./item-edit.component.css']
})
export class ItemEditComponent implements OnInit {

  constructor(private route:ActivatedRoute, public itemsService : ItemsService, private location: Location) { }

  editableItem: BeItem;
  categories: Category[];
  ngOnInit() {
    this.getItem();
    this.getCategoryList();
  }
  i: number;
  getItem(): void {
    const id = + this.route.snapshot.paramMap.get('id');
    console.log("item id : " + id);
    this.itemsService.getItem(id)
      .subscribe(itemFromServer =>{
        this.editableItem = itemFromServer;
        console.log(this.editableItem);
      } );
  }

  
  getCategoryList():void{
    this.itemsService.getCategories().subscribe(categoriesFromDb => {
      console.log("getCategories");
      console.log(categoriesFromDb);
      this.categories = categoriesFromDb;
    });
  }

  setCategory(category: Category){
    this.editableItem.Categories.push(category);
  }

  goBack(): void {
    this.location.back();
  }
  
  updateItem() : void {
    this.itemsService.updateItem(this.editableItem).subscribe(editedItem => {
      console.log("Item edit success");
      console.log("New item:");
      console.log(editedItem);
    });
    console.log("todo item update");
  }

}
