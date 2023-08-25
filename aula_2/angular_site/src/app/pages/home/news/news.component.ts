import { Component, OnInit } from '@angular/core';
import { Result } from 'src/app/shared/result';
import { News } from '../models/news';
import { NewsService } from './services/news.service';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.css']
})
export class NewsComponent implements OnInit {

  constructor(private _newsService: NewsService) { }

  page: number = 1;
  qtd: number = 4;
  totalPages: number[] = [];
  hasPagination = false;
  public newsList: News[] | undefined = new Array<News>();

  ngOnInit() {
    this.getNews(this.page, this.qtd);
  }



  pagination(page: number) {
    this.page = page;
    this.getNews(this.page, this.qtd);
  }

  getNews(page: number, qtd: number) {
    this._newsService.getNews(page, qtd).subscribe((result: Result<News>) => {
      let obj = result;
      this.totalPages = new Array(obj.totalPages)
      this.hasPagination = this.totalPages.length > 1;

      this.newsList = obj.data;
    });
  }

}
