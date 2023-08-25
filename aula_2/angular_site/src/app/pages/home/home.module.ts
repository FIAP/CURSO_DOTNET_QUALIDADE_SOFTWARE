import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { InternalComponent } from './internal/internal.component';
import { NewsComponent } from './news/news.component';
import { VideoComponent } from './video/video.component';
import { VimeModule } from '@vime/angular';
import { GalleryComponent } from './gallery/gallery.component';
import { NgImageSliderModule } from 'ng-image-slider';


@NgModule({
  declarations: [
    HomeComponent,
    InternalComponent,
    NewsComponent,
    VideoComponent,
    GalleryComponent
  ],
  imports: [
    CommonModule,
    HomeRoutingModule,
    VimeModule,
    NgImageSliderModule    
  ]
})

export class HomeModule { }
