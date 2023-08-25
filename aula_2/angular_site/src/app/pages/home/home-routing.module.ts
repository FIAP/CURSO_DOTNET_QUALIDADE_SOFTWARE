import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GalleryComponent } from './gallery/gallery.component';
import { HomeComponent } from './home.component';
import { InternalComponent } from './internal/internal.component';
import { NewsComponent } from './news/news.component';
import { VideoComponent } from './video/video.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'noticias/:slug', component: InternalComponent },
  { path: 'videos/:slug', component: VideoComponent },
  { path: 'galeria/:slug', component: GalleryComponent },
  { path: 'noticias', component: NewsComponent }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
