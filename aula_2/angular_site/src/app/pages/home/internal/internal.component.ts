import { ActivatedRoute } from '@angular/router';
import { OnInit, Component } from '@angular/core';
import { InternalService } from './services/internal.service';
import { News } from '../models/news';

@Component({
  selector: 'app-internal',
  templateUrl: './internal.component.html',
  styleUrls: ['./internal.component.css']
})
export class InternalComponent implements OnInit {

  constructor(private activatedRoute: ActivatedRoute, private internalService: InternalService) { }
  public news: News = new News();

  ngOnInit() {
    let slug = this.activatedRoute.snapshot.params.slug;    
    this.getNewsBySlug(slug);
  }

  getNewsBySlug(slug: string) {
    this.internalService.getNewsBySlug(slug).subscribe(data => {      
      this.news = data;
    });
  }

}
