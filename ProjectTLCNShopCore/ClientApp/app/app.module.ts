import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AUTH_PROVIDERS } from 'angular2-jwt';
import { routing, appRoutingProviders } from './components/routes/app.routes';

import { HttpModule, JsonpModule } from '@angular/http';
import { UniversalModule } from 'angular2-universal';
import { AppComponent } from './components/app/app.component';
import { HomeComponent } from './components/home/home.component';
import { ContactComponent } from './components/contact/contact.component';


@NgModule({
    bootstrap: [ AppComponent],
    declarations: [
        AppComponent,
        HomeComponent,
        ContactComponent
        
    ],
    providers: [
        appRoutingProviders,
        AUTH_PROVIDERS
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
