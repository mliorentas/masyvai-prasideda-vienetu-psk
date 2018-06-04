import { Component, OnInit } from '@angular/core';
import { Category } from '../category';
import { ItemsService } from '../items.service';
import { AlertService } from '../alert.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-category-create',
  templateUrl: './category-create.component.html',
  styleUrls: ['./category-create.component.css']
})
export class CategoryCreateComponent implements OnInit {

  newCategory : Category = new Category();

  constructor(public itemsService : ItemsService, public alertService : AlertService, public router : Router) { }

  ngOnInit() {
  }

  createCategory() : void {
    console.log("create category");
    console.log(this.newCategory);
    this.itemsService.createCategory(this.newCategory);
    this.alertService.success("Kategorija sėkmingai sukurta", true);
    this.router.navigateByUrl('/home');
  }

}
