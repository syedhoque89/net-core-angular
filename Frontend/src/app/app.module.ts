import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppComponent} from './app.component';
import {HttpClientModule} from "@angular/common/http";
import { FeatureImageComponent } from './components/feature-image/feature-image.component';
import { LeadProductsComponent } from './components/lead-products/lead-products.component';
import { LocationComponent } from './components/location/location.component';
import { StarRatingComponent } from './components/star-rating/star-rating.component';
import { SubtitleComponent } from './components/subtitle/subtitle.component';
import { TitleComponent } from './components/title/title.component';

@NgModule({
  declarations: [
    AppComponent,
    FeatureImageComponent,
    LeadProductsComponent,
    LocationComponent,
    StarRatingComponent,
    SubtitleComponent,
    TitleComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
