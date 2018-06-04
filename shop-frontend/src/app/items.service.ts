import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Item } from './/item';
import { ITEMS } from './mock-items';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';
import { Attribute } from './attribute';
import { Category } from './category';
import { BeItem } from './be-item';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Access-Control-Allow-Origin': '*',
  }),
  withCredencials: true
};

@Injectable()
export class ItemsService {
  constructor(private http: HttpClient) { }

  getItems(): Observable<Item[]> {
    // TODO: send the message _after_ fetching the heroes
    // this.messageService.add('HeroService: fetched heroes');
    return this.http.get<Item[]>('http://localhost:59134/item/all', httpOptions);
  }

  getCategories(): Observable<Category[]> {
    // TODO: send the message _after_ fetching the hero
    // this.messageService.add(`HeroService: fetched hero id=${id}`);
    return this.http.get<Category[]>('http://localhost:59134/category/all', httpOptions);
  }

  createCategory(category: Category){
    // TODO: send the message _after_ fetching the hero
    // this.messageService.add(`HeroService: fetched hero id=${id}`);
    return this.http.post<Category>('http://localhost:59134/category/add', category, httpOptions).subscribe(r => { console.log(r) });
  }

  deleteItem(itemId: number): Observable<Item> {
    console.log("deleteItem");
    console.log(itemId);
    // TODO: send the message _after_ fetching the heroes
    // this.messageService.add('HeroService: fetched heroes');
    return this.http.delete<Item>('http://localhost:59134/item/delete/' + itemId, httpOptions)
  }

  private extractData(res: Response) {
    let body = res.json();
    return body || {};
  }

  private handleError(error: any) {
    let errMsg = (error.message) ? error.message :
      error.status ? `${error.status} - ${error.statusText}` : 'Server error';
    console.error(errMsg);
    return Observable.throw(errMsg);
  }

  getItem(id: number): Observable<BeItem> {
    // TODO: send the message _after_ fetching the hero
    // this.messageService.add(`HeroService: fetched hero id=${id}`);
    return this.http.get<BeItem>('http://localhost:59134/item/' + id, httpOptions);
  }

  updateItem(item: BeItem): Observable<BeItem> {
    console.log("try to update object");
    return this.http.put<BeItem>('http://localhost:59134/item/update', item, httpOptions);
  }

  createItem(item: BeItem, properties: Attribute) {
    let newItem = {
      "Id": 0,
      "Name": item.Name,
      "Description": item.Description,
      "SkuCode": item.SkuCode,
      "Discount": item.Discount,
      "Price": item.Price,
      "IsDisabled": false,
      "DiscountedPrice": 0,
      "Images": [
        {
          "Id": 0,
          "ImageUrl": item.Images[0].ImageUrl
        }
      ],
      "Categories": [
        {
          "Id": item.Categories[0].Id,
          "Name": item.Categories[0].Name,
          "Description": item.Categories[0].Description
        }
      ],
      "Property": {
        "Id": 0,
        "Ilgis": item.Property.Ilgis,
        "Plotis": item.Property.Plotis,
        "Ratai": item.Property.Ratai,
        "Guoliai": item.Property.Guoliai,
        "MaksimalusSvoris": item.Property.MaksimalusSvoris,
        "Spalva": item.Property.Spalva,
        "Asys": item.Property.Asys,
        "Paskirtis": item.Property.Paskirtis,
        "Gamintojas": item.Property.Gamintojas,
        "Dydis": item.Property.Dydis,
        "Storis": item.Property.Storis,
        "Kietumas": item.Property.Kietumas,
        "Skirta": item.Property.Skirta
      }
    }
    console.log("postinamas itemas:");
    console.log(newItem);
    return this.http.post<Item>('http://localhost:59134/item/add', newItem, httpOptions).subscribe(r => { console.log(r) });
  }

  searchItems(search:string): Observable<Item[]> {
    // TODO: send the message _after_ fetching the heroes
    // this.messageService.add('HeroService: fetched heroes');
    return this.http.get<Item[]>('http://localhost:59134/item/search/'+ search, httpOptions);
  }

}