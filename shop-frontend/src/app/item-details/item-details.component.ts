import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ItemsService } from '../items.service';
import { Item } from '../item';
import { Location } from '@angular/common';
import { BeItem } from '../be-item';
import { CartService } from '../cart.service';

@Component({
  selector: 'app-item-details',
  templateUrl: './item-details.component.html',
  styleUrls: ['./item-details.component.css']
})
export class ItemDetailsComponent implements OnInit {
  item: BeItem;
  constructor(private route: ActivatedRoute, 
    private itemsService: ItemsService, 
    private location: Location,
    public cartService : CartService) { }
  selectedPhoto: string;
  ngOnInit() {
    this.getItem();
  }
  i: number;
  getItem(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.itemsService.getItem(id)
      .subscribe(item =>{
        this.item = item
        console.log(this.item);
      } );
  }
  selectPhoto(photo: string): void
  {
    this.selectedPhoto = photo;
  }
  goBack(): void {
    this.location.back();
  }

  buyItem():void {
    this.cartService.addItem(this.item);
  }
}
