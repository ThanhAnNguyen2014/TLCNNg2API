import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { UniversalModule } from 'angular2-universal';
import { AppComponent } from './components/app/app.component'

@NgModule({
    bootstrap: [ AppComponent],
    declarations: [
        AppComponent,
        
    ],
    imports: [
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
    ]
})
export class AppModule {
}
