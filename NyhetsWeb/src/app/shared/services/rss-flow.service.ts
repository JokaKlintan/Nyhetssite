import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { IRSSFeedModel } from '../models/IRSSFeedModel.interface';

@Injectable()
export class RssFlowService{
  private apiUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getRssFeeds(): Observable<IRSSFeedModel>{
    return this.http.get<IRSSFeedModel>(this.apiUrl + '/api/rssflow/rssfeed').pipe(catchError(this.handleError));
  }

  getNTRssFeeds(): Observable<IRSSFeedModel>{
    return this.http.get<IRSSFeedModel>(this.apiUrl + '/api/rssflow/ntrssfeed').pipe(catchError(this.handleError));
  }

  getExpressenRssFeeds(): Observable<IRSSFeedModel>{
    return this.http.get<IRSSFeedModel>(this.apiUrl + '/api/rssflow/expressenrssfeed').pipe(catchError(this.handleError));
  }

  getSvdRssFeeds(): Observable<IRSSFeedModel>{
    return this.http.get<IRSSFeedModel>(this.apiUrl + '/api/rssflow/svdrssfeed').pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse){
    if (error.error instanceof ErrorEvent) {
      console.error('An error occurred:', error.error.message);
    } else {
      console.error(`Backend returned code ${error.status}, ` + `body was: ${error.error}`);
    }
    return throwError(
      'Something bad happened; please try again later.');
    }
}
