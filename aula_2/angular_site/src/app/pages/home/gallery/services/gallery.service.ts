import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, delay, map, retryWhen, take } from 'rxjs/operators';
import { HttpUtilService } from 'src/app/shared/http-util.service';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GalleryService {

  private API_URL = environment.URL;

  constructor(private http: HttpClient, private httpUtil: HttpUtilService) { }

  getGallery(page: number, qtd: number) {
    return this.http.get(this.API_URL + `galleryexternal/${page}/${qtd}`)
      .pipe(map(this.httpUtil.extrairDados))
      .pipe(
        retryWhen(errors => errors.pipe(delay(1000), take(10))),
        catchError(this.httpUtil.processarErros));
  }


  
  getGalleryBySlug(slug: string) {
    return this.http.get(this.API_URL + `GalleryExternal/${slug}`)
      .pipe(map(this.httpUtil.extrairDados))
      .pipe(
        retryWhen(errors => errors.pipe(delay(1000), take(10))),
        catchError(this.httpUtil.processarErros));
  }
}