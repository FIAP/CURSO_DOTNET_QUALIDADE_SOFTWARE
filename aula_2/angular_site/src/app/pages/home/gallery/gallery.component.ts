import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { InternalService } from '../internal/services/internal.service';
import { Gallery } from '../models/gallery';
import { GalleryService } from './services/gallery.service';

@Component({
  selector: 'app-gallery',
  templateUrl: './gallery.component.html',
  styleUrls: ['./gallery.component.css']
})
export class GalleryComponent implements OnInit {

  constructor(private activatedRoute: ActivatedRoute, private _galleryService: GalleryService) { }
  public gallery: Gallery = new Gallery();

  imageObject: Array<object> = [];

  ngOnInit(): void {

    let slug = this.activatedRoute.snapshot.params.slug;
    this.getGalleryBySlug(slug);
  }

  getGalleryBySlug(slug: string) {

    this._galleryService.getGalleryBySlug(slug).subscribe((data: Gallery) => {
      this.gallery = data;
      
      data.galleryImages?.forEach(img => {

        let element = {
          image: img,
          thumbImage: img,
          alt: '',
          title: this.gallery.title
        };
        console.log(element, 'HERE');

        this.imageObject.push(element);

      });



    });
  }

}
