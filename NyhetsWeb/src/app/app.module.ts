import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { MomentModule } from 'ngx-moment';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NorrkopingNewspapersComponent } from './norrkoping-newspapers/norrkoping-newspapers.component';
import { NewsFlowComponent } from './news-flow/news-flow.component';
import { ExpressenComponent } from './expressen/expressen.component';
import { SvdComponent } from './svd/svd.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RssFlowService } from './shared/services/rss-flow.service';
import { RssFeedDataListComponent } from './shared/components/rss-feed-data-list/rss-feed-data-list.component';
import { RssFeedSourceDataComponent } from './shared/components/rss-feed-source-data/rss-feed-source-data.component';

@NgModule({
  declarations: [
    AppComponent,
    NorrkopingNewspapersComponent,
    NewsFlowComponent,
    ExpressenComponent,
    SvdComponent,
    RssFeedDataListComponent,
    RssFeedSourceDataComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    HttpClientModule,
    MomentModule.forRoot({
      relativeTimeThresholdOptions: {
        'm': 59
      }
    })
  ],
  providers: [RssFlowService],
  bootstrap: [AppComponent]
})
export class AppModule { }
