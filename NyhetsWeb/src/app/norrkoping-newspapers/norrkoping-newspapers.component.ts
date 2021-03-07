import { Component, OnInit } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { RssFlowService } from '../shared/services/rss-flow.service';
import { IRSSFeedModel } from '../shared/models/IRSSFeedModel.interface';

@Component({
  selector: 'app-norrkoping-newspapers',
  templateUrl: './norrkoping-newspapers.component.html',
  styleUrls: ['./norrkoping-newspapers.component.css']
})
export class NorrkopingNewspapersComponent implements OnInit {
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
    this.rssFlowService.getNTRssFeeds().pipe(finalize(() => { console.log("Finalizing") })).subscribe((result: IRSSFeedModel) => {
      this.model = result;
    }, error => {
      console.log(error);
    });
  }
}
