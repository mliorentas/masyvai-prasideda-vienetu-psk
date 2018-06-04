import { Component, OnInit } from '@angular/core';
import { Item } from '../item';
import { ItemsService } from '../items.service';
import { Attribute } from '../attribute';
import { Category } from '../category';
import { BeItem } from '../be-item';
import { Image } from '../image';
import { AlertService } from '../alert.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-item-create',
  templateUrl: './item-create.component.html',
  styleUrls: ['./item-create.component.css']
})
export class ItemCreateComponent implements OnInit {

  constructor(private itemsService: ItemsService,
    public alertService: AlertService,
    public router: Router) {
  }

  createbleItem: BeItem = new BeItem();
  createbleItemAttributes: Attribute = new Attribute();
  itemsCategory: number;
  itemsCategoryObj: Category;
  itemsCategories: Category[] = [];
  categories: Category[];
  imageToPush : Image = new Image();
  imagesArray: Image[] = [];

  ngOnInit() {
    console.log("on init");
    this.getCategoryList();
    this.createbleItem.Property = this.createbleItemAttributes;
    this.createbleItem.Images = this.imagesArray;
  }

  createItem(): void {
    console.log("create item");
    this.setCategoryById();
    console.log(this.createbleItem);
    this.createbleItem.Images.push(this.imageToPush);
    this.itemsService.createItem(this.createbleItem, this.createbleItemAttributes);
    this.alertService.success("Prekė sėkmingai sukurta", true);
    this.router.navigateByUrl('/home');
  }

  getCategoryList(): void {
    this.itemsService.getCategories().subscribe(categoriesFromDb => {
      console.log("getCategories");
      console.log(categoriesFromDb);
      this.categories = categoriesFromDb;
    });
  }

  setCategory(category: Category) {
    console.log("set category");
    this.itemsCategories[0] = category;
    this.createbleItem.Categories = this.itemsCategories;
    console.log(this.createbleItem.Categories);
    console.log(this.createbleItem);
  }

  setCategoryById() {
    this.categories.forEach(element => {
      console.log("set category by id");
      console.log(element);
      console.log(this.itemsCategory);
      if (element.Id == this.itemsCategory) {
        console.log("atitinkanti kategorija");
        console.log(element);
        this.setCategory(element);
      }
    });
  }
}
