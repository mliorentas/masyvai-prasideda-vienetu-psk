import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { BeOrder } from './be-order';
import { User } from './user';
import { UserService } from './user.service'

import { BeFullOrder } from './be-full-order'
const httpOptions = {
  headers: new HttpHeaders({ 
    'Content-Type': 'application/json',
    'Access-Control-Allow-Origin': '*'
  }),
  withCredentials: true,
  observe: "response" as "body"
};

const httpOptions2 = {
  headers: new HttpHeaders({ 
    'Content-Type': 'application/json',
    'Access-Control-Allow-Origin': '*'
  }),
  withCredentials: true
};

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  
  public orderToPay: BeFullOrder;

  private url = 'http://localhost:59134/';

  constructor(
    private http: HttpClient,
    private userService: UserService
  ) { }

  /** POST: add a new order to the order-service */
  addOrder (order: BeOrder) {
    return this.http.post<HttpResponse<BeFullOrder>>(this.url + 'order/add', order, httpOptions);
  }

  updateOrder (order: BeFullOrder) {
    return this.http.put<HttpResponse<BeFullOrder>>(this.url + 'order/editStatus', order, httpOptions);
  }

  getUserOrders () {
    return this.http.get<BeFullOrder[]>(this.url + 'user/myOrders', httpOptions2);
  }

  getOrderById (id :number) {
    return this.http.get<BeFullOrder>(this.url + 'user/order/'+id, httpOptions2);
  }

  getAllOrders () {
    return this.http.get<BeFullOrder[]>(this.url + 'order/all', httpOptions2);
  }
  
  isOrderOfCurrentUser(order: BeFullOrder): boolean {
    return order.User.Id === this.userService.currentUser.Id;
  }
}
