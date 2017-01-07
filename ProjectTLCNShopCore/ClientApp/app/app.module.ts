import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AUTH_PROVIDERS } from 'angular2-jwt';
import { FormsModule } from "@angular/forms";
//import { routing, appRoutingProviders } from './components/routes/app.routes';
import "rxjs/Rx";

import { HttpModule, JsonpModule } from '@angular/http';
import { UniversalModule } from 'angular2-universal';
import { AppComponent } from './components/app/app.component';
import { HeaderComponent } from './components/header/header.component';
import { BannerComponent } from './components/banner/banner.component';
import { SliderComponent } from './components/slider/slider.component';
//import { ContactComponent } from './components/contact/contact.component';
//import { CheckOutService } from './components/service/checkout.service';

@NgModule({
    bootstrap: [AppComponent, BannerComponent],
    declarations: [
        AppComponent,
        HeaderComponent,
        BannerComponent,
        SliderComponent
        //ContactComponent
        
    ],
    providers: [
        //appRoutingProviders,
        AUTH_PROVIDERS,
        //CheckOutService
    ],
    imports: [
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        HttpModule,
        FormsModule,
        JsonpModule,
       // routing
    ]
})
export class AppModule {
}
