import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { UserFilterPipe, OrderFilterPipe, ItemFilterPipe } from './filter.pipe';

import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { NavbarComponent } from './navbar/navbar.component';
import { AppRoutingModule } from './/app-routing.module';
import { HomeComponent } from './home/home.component';
import { FooterComponent } from './footer/footer.component';
import { LogInComponent } from './log-in/log-in.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ItemComponent } from './item/item.component';
import { ItemListComponent } from './item-list/item-list.component';
import { UsersComponent } from './users/users.component';
import { ItemDetailsComponent } from './item-details/item-details.component';
import { ItemsService } from './/items.service';
import { OrderListComponent } from './order-list/order-list.component';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { ModalModule } from 'ngx-bootstrap/modal';
import { CartComponent } from './cart/cart.component';
import { CartService } from './cart.service';
import { UserEditComponent } from './user-edit/user-edit.component'
import { UserService } from './user.service';
import { ItemCreateComponent } from './item-create/item-create.component';
import { AlertComponent } from './alert/alert.component';
import { AlertService } from './alert.service';
import { ItemEditComponent } from './item-edit/item-edit.component';
import { PaymentComponent } from './payment/payment.component';
import { OrderComponent } from './order/order.component';
import { OrderEditComponent } from './order-edit/order-edit.component';
import { CategoryCreateComponent } from './category-create/category-create.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    NavbarComponent,
    HomeComponent,
    FooterComponent,
    LogInComponent,
    SignInComponent,
    ItemComponent,
    ItemListComponent,
    UsersComponent,
    ItemDetailsComponent,
    OrderListComponent,
    CartComponent,
    UserEditComponent,
    ItemCreateComponent,
    UserFilterPipe,
    OrderFilterPipe,
    ItemFilterPipe,
    AlertComponent,
    PaymentComponent, 
    OrderComponent, 
    ItemEditComponent, OrderEditComponent, CategoryCreateComponent
  ],
  imports: [  
    BrowserModule,
    FormsModule,
    BsDropdownModule.forRoot(),
    ModalModule.forRoot(),
    TooltipModule.forRoot(),
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [ItemsService, CartService, AlertService],
  bootstrap: [AppComponent]
})
export class AppModule { }
