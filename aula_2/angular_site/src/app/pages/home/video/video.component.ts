import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Result } from 'src/app/shared/result';
import { Video } from '../models/video';
import { VideoService } from './services/video.service';



@Component({
  selector: 'app-video',
  templateUrl: './video.component.html',
  styleUrls: ['./video.component.css']
})
export class VideoComponent implements OnInit {

  totalPages: number[] = [];
  hasPagination = false;
  public videoList: Video[] | undefined = new Array<Video>();
  video: Video | undefined;
  vidObj: any;

  @ViewChild('myvid', { static: true })
  vid!: ElementRef;
  videoUrl?: String;


  constructor(private activatedRoute: ActivatedRoute, private _videoService: VideoService) { }


  ngOnInit() {
    let slug = this.activatedRoute.snapshot.params.slug;
    this.getVideosBySlug(slug);
  }




  getVideos(slug: string) {
    this._videoService.getVideosBySlug(slug).subscribe((result: Result<Video>) => {
      let obj = result;
      this.totalPages = new Array(obj.total)
      this.hasPagination = this.totalPages.length > 1;

      this.videoList = obj.data;
    });
  }

  getVideosBySlug(slug: string) {
    this._videoService.getVideosBySlug(slug).subscribe((data: Video) => {
      this.video = data;
      this.videoUrl = this.video.urlVideo;
      console.log(this.videoUrl, 'OBJ');
    });
  }


}
