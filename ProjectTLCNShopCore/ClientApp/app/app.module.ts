import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { AUTH_PROVIDERS } from 'angular2-jwt';
import { routing, appRoutingProviders } from './components/routes/app.routes';
//service
import { AuthGuard } from './components/guard/auth.guard';
import { Auth } from './components/service/auth.service';
import { TestHttpService } from './components/service/test-http.service';
import { CategoryService } from './components/service/category.service';
import { ProductService } from './components/service/product.service';
import { ContactService } from './components/service/contact.service';
import { UserService } from './components/service/user.service';
import { CartService } from './components/service/cart.service';
import { CheckOutService } from './components/service/checkout.service';
import { SearchService } from './components/service/search.service';

import './rxjs-extensions';

import { BrowserModule } from '@angular/platform-browser';


import { HttpModule, JsonpModule } from '@angular/http';
import { UniversalModule } from 'angular2-universal';
import { AppComponent } from './components/app/app.component';
import { HomeComponent } from './components/home/home.component';
import { HeaderComponent } from './components/_header/header.component';
import { SlideComponent } from './components/_slide/slide.component';
import { FooterComponent } from './components/_footer/footer.component';

import { AboutComponent } from './components/about/about.component';
import { ContactComponent } from './components/contact/contact.component';
import { ProfileComponent } from './components/profile/profile.component';
import { CategoryComponent, ExplodePipe } from './components/category/category.component';
import { DetailComponent } from './components/detail/detail.component';
import { CartComponent } from './components/cart/cart.component';
import { CheckOutComponent } from './components/checkout/checkout.component';
import { SearchComponent } from './components/search/search.component';


import { TestComponent } from './components/test/test.component';
import { TestHttpComponent } from './components/test-http/test-http.component';



@NgModule({
    bootstrap: [ AppComponent],
    declarations: [
        AppComponent,
        HomeComponent,
        SlideComponent,
        HeaderComponent,
        FooterComponent,
        ContactComponent,
        CategoryComponent,
        TestComponent,
        CartComponent,
        DetailComponent,
        AboutComponent,
        ProfileComponent,
        //test-http
        TestHttpComponent,
        CheckOutComponent,
        SearchComponent,
       
        
        ExplodePipe

        
    ],
    providers: [
        appRoutingProviders,
        AUTH_PROVIDERS,
        Auth,
        AuthGuard,
        TestHttpService,
        CategoryService,
        ProductService,
        ContactService,
        UserService,
        CartService,
        CheckOutService,
        SearchService
        
    ],
    imports: [
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        HttpModule,
        JsonpModule,
        routing,
        FormsModule
    ]
})
export class AppModule {
}
