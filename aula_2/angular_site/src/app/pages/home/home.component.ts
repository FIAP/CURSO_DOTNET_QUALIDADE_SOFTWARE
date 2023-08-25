import { Component, OnInit } from '@angular/core';
import { Result } from 'src/app/shared/result';
import { GalleryService } from './gallery/services/gallery.service';
import { Gallery } from './models/gallery';
import { News } from './models/news';
import { Video } from './models/video';
import { HomeService } from './services/home.service';
import { VideoService } from './video/services/video.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(
    private _galleryService: GalleryService,
    private homeService: HomeService,
    private _videoService: VideoService) { }

  public newsList: News[] | undefined = new Array<News>();
  videoList: Video[] | undefined;
  galleryList: Gallery[] | undefined;




  public newsStandard: News | undefined = new News();

  ngOnInit() {
    this.getNews();
    this.getVideos(1, 4);
    this.getGallery(1, 4);
  }

  getNews() {
    this.homeService.getNews().subscribe((result: Result<News>) => {
      let obj: any = result;
      this.newsList = obj.data;
      this.newsStandard = obj.data[0];
      console.log(this.newsStandard)
    });
  }

  getVideos(page: number, qtd: number) {
    this._videoService.getVideos(page, qtd).subscribe((result: Result<Video>) => {
      let obj = result;
      this.videoList = obj.data;
    });
  }


  getGallery(page: number, qtd: number) {
    this._galleryService.getGallery(page, qtd).subscribe((result: Result<Gallery>) => {
      let obj = result;
      this.galleryList = obj.data;
      console.log(this.galleryList);
    });
  }

}
