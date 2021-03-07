import { Component, OnInit } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { RssFlowService } from '../shared/services/rss-flow.service';
import { IRSSFeedModel } from '../shared/models/IRSSFeedModel.interface';

@Component({
  selector: 'app-news-flow',
  templateUrl: './news-flow.component.html',
  styleUrls: ['./news-flow.component.css']
})
export class NewsFlowComponent implements OnInit {
  public model: IRSSFeedModel;

  constructor(public rssFlowService: RssFlowService) {
    this.model = {
      Source: {
        Title: '',
        Description: '',
        Link: '',
        CopyRight: '',
        ManagingEditor: '',
        ImageUrl: '',
        Language: '',
        LastBuildDate: ''
      },
      Items: []
    };
  }

  ngOnInit(): void {
    this.rssFlowService.getRssFeeds().pipe(finalize(() => { console.log("Finalizing") })).subscribe((result: IRSSFeedModel) => {
      this.model = result;
    }, error => {
      console.log(error);
    });
  }
}
