import { Component, OnInit, Input } from '@angular/core';
import { IRSSFeedItemModel } from '../../models/IRSSFeedItemModel.interface';

@Component({
  selector: 'app-rss-feed-data-list',
  templateUrl: './rss-feed-data-list.component.html',
})
export class RssFeedDataListComponent implements OnInit {
  @Input() model: IRSSFeedItemModel[];

  @Input() source: string;
  
  constructor(){
    this.model = [];
    this.source = '';
  }

  ngOnInit(): void {}
}
