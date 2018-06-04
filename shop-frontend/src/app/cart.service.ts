import { Injectable } from '@angular/core';
import { Cart } from './/cart';
import { BeItem } from './/be-item';
import { ITEMS } from './mock-items';
import { Observable, of } from 'rxjs';
import { cartItem } from './cartItem';
import { ItemQuantity } from './item-quantity'

@Injectable()
export class CartService {

    cart: Cart = {
        items: [],
        price: 0
    }

    constructionFlag = true;

    constructor() {
        if (this.getItemsIdArray()) {
            this.getItemsIdArray().forEach(element => {
                let creatableItem = this.getItemById(parseInt(element));
                console.log(creatableItem);
                this.addItem(creatableItem);
            });
        }
        this.constructionFlag = false;
    }

    getItemById(itemId: number): BeItem {
        let returnableItem = null
        ITEMS.forEach(element => {
            if (element.Id == itemId) {
                console.log(element);
                returnableItem = element;
            }
        });
        return returnableItem;
    }

    getItemsIdArray(): string[] {
        if (localStorage.getItem("itemsCart") != null) {
            return localStorage.getItem("itemsCart").split(",");
        } else {
            return null;
        }
    }

    public addItem(item: BeItem): void {
        console.log("add to cart");
        console.log(item);
        let currentId: number;
        let flag = true;

        if(item == null)
            return;

        this.cart.items.forEach(cartItem => {
            if (cartItem.item.Id == item.Id) {
                cartItem.quantity++;
                currentId = cartItem.id;
                flag = false;
            }
        });
        if (flag) {
            let newItem: cartItem = {
                item: item,
                quantity: 1,
                id: currentId + 1
            }
            console.log(this.cart.items);
            this.cart.items.push(newItem);
        }
        if (!this.constructionFlag) {
            this.addToLocalStorageCart(item);
        }
        this.changePriceOfCart();
    }

    public changePriceOfCart(): number {
        this.cart.price = 0;
        this.cart.items.forEach(element => {
            if (element.item != null) {
                this.cart.price += element.item.DiscountedPrice * element.quantity;
            }
        });
        return
    }

    public removeFromCart(item: cartItem): void {
        for (let i = 0; i < this.cart.items.length; i++) {
            if (item == this.cart.items[i]) {
                if (this.cart.items[i].quantity == 1) {
                    this.cart.items.splice(i, 1);
                } else {
                    this.cart.items[i].quantity--;
                }
                this.changePriceOfCart();
                let localStorageItems = localStorage.getItem("itemsCart");
                let array = localStorageItems.split(",");
                for (let j = 0; j < array.length; j++) {
                    if (parseInt(array[j]) == item.item.Id) {
                        array.splice(j, 1);
                        if (array.length == 0) {
                            localStorage.removeItem("itemsCart")
                        } else {
                            localStorage.setItem("itemsCart", array.join());
                            break;
                        }
                    }
                }
            }
        }
    }


    public addToLocalStorageCart(item: BeItem): void {
        if (localStorage.getItem("itemsCart") === null) {
            localStorage.setItem("itemsCart", "" + item.Id);
        } else {
            localStorage.setItem("itemsCart", localStorage.getItem("itemsCart") + "," + item.Id);
        }
    }

    public getItemsCartFromLocalStorage(): string {
        return localStorage.getItem("itemsCart");
    }

    public getItemQuantity(): ItemQuantity[] {
        let result: ItemQuantity[] = [];
        this.cart.items.forEach(element => {
            if (element.item != null) {
                let itemQuantity: ItemQuantity = new ItemQuantity;
                itemQuantity.ItemId = element.item.Id;
                itemQuantity.ItemQty = element.quantity;
                result.push(itemQuantity);
            }
        });
        return result;
    }

    public isEmpty(): boolean {
        return this.cart.items.length === 0;
    }

    public clearCart(): void {
        this.cart.items = [];
        this.cart.price = 0;
    }
}