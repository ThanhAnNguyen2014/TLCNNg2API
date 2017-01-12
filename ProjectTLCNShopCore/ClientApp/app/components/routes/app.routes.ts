import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../guard/auth.guard';

import { HomeComponent } from '../home/home.component';
import { ContactComponent } from '../contact/contact.component';
import { ProfileComponent } from '../profile/profile.component';
import { AboutComponent } from '../about/about.component';
import { CategoryComponent } from '../category/category.component';
import { DetailComponent } from '../detail/detail.component';
import { CartComponent } from '../cart/cart.component';
import { CheckOutComponent } from '../checkout/checkout.component';
import { SearchComponent } from '../search/search.component';


import { TestComponent } from '../test/test.component';
import { TestHttpComponent } from '../test-http/test-http.component';


const appRoutes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'contact', component: ContactComponent },
    { path: 'category/:id', component: CategoryComponent },
    { path: 'detail/:id', component: DetailComponent },
    { path: 'search/:searchstring', component: SearchComponent },
    { path: 'cart', component: CartComponent },
    { path: 'about', component: AboutComponent },
    { path: 'test', component: TestComponent },
    { path: 'test-http', component: TestHttpComponent },
    { path: 'checkout', component: CheckOutComponent },
    { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard] },
    { path: '**', redirectTo: 'home' }
];

export const appRoutingProviders: any[] = [

];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);