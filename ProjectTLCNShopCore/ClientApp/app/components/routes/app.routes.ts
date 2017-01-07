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



const appRoutes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'contact', component: ContactComponent },
    { path: 'category', component: CategoryComponent },
    { path: 'detail', component: DetailComponent },
    { path: 'cart', component: CartComponent },
    { path: 'about', component: AboutComponent },
    { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard] },
    { path: '**', redirectTo: 'home' }
];

export const appRoutingProviders: any[] = [

];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);