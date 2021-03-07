import { Component, OnInit, Input } from '@angular/core';
import { IRSSFeedSourceModel } from '../../models/IRSSFeedSourceModel.interface';

@Component({
  selector: 'app-rss-feed-source-data',
  templateUrl: './rss-feed-source-data.component.html',
})
export class RssFeedSourceDataComponent implements OnInit {
  @Input() model: IRSSFeedSourceModel;

  constructor(){
    this.model = {
      Title: '',
      Description: '',
      Link: '',
      CopyRight: '',
      ManagingEditor: '',
      ImageUrl: '',
      Language: '',
      LastBuildDate: ''
    };
  }

  ngOnInit(): void {}
}
