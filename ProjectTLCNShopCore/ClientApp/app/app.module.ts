import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AUTH_PROVIDERS } from 'angular2-jwt';
import { routing, appRoutingProviders } from './components/routes/app.routes';
import { AuthGuard } from './components/guard/auth.guard';
import { Auth } from './components/service/auth.service';

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
import { CategoryComponent } from './components/category/category.component';
import { DetailComponent } from './components/detail/detail.component';
import { CartComponent } from './components/cart/cart.component';


@NgModule({
    bootstrap: [AppComponent],
    declarations: [
        AppComponent,
        HomeComponent,
        SlideComponent,
        HeaderComponent,
        FooterComponent,
        ContactComponent,
        CategoryComponent,
        CartComponent,
        DetailComponent,
        AboutComponent,
        ProfileComponent

    ],
    providers: [
        appRoutingProviders,
        AUTH_PROVIDERS,
        Auth,
        AuthGuard
    ],
    imports: [
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        HttpModule,
        JsonpModule,
        routing
    ]
})
export class AppModule {
}
