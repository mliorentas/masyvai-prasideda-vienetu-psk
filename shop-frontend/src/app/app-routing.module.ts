import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LogInComponent } from './log-in/log-in.component';
import { ItemDetailsComponent } from './item-details/item-details.component';
import { UsersComponent } from './users/users.component';
import { OrderListComponent } from './order-list/order-list.component';
import { CartComponent } from './cart/cart.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { UserEditComponent } from './user-edit/user-edit.component';
import { ItemCreateComponent } from './item-create/item-create.component';
import { ItemEditComponent } from './item-edit/item-edit.component';
import { PaymentComponent } from './payment/payment.component';
import { OrderComponent } from './order/order.component'
import { OrderEditComponent } from './order-edit/order-edit.component';
import { CategoryCreateComponent } from './category-create/category-create.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'home/:search', component: HomeComponent },
  { path: 'log-in', component: LogInComponent },
  { path: 'sign-in', component: SignInComponent },
  { path: 'users', component:UsersComponent },
  { path: 'user-edit', component:UserEditComponent },
  { path: 'orders', component:OrderListComponent },
  { path: 'cart', component:CartComponent },
  { path: 'item-details/:id', component: ItemDetailsComponent },
  { path: 'item-edit/:id', component: ItemEditComponent },
  { path: 'order-edit/:id', component: OrderEditComponent },
  { path: 'item-create', component: ItemCreateComponent },
  { path: 'category-create', component: CategoryCreateComponent },
  { path: 'payment', component: PaymentComponent },
  { path: 'order', component: OrderComponent }
  // { path: 'dashboard', component: DashboardComponent },
  // { path: 'detail/:id', component: HeroDetailComponent },
];

@NgModule({
  exports: [ RouterModule ],
  imports: [ RouterModule.forRoot(routes) ]

})
export class AppRoutingModule {}