import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { FeedResponse } from '../interfaces/feed-response';

@Injectable({
  providedIn: 'root'
})
export class FeedService {
  private feedApiUrl = '/api/feed';
  loading: boolean;
  feedResponse: FeedResponse;

  constructor(private http: HttpClient)
  {
    this.loading = true;
    this.feedResponse = { } as FeedResponse;
  }

  //Get
  getLatestFeed(sort: string, order: string): Observable<FeedResponse> {
    this.loading = true;
    return this.http.get<FeedResponse>(`${this.feedApiUrl}/latest?sort=${sort}&order=${order}`)
      .pipe(
        catchError(this.handleError<FeedResponse>('getLatest', {} as FeedResponse))
      );
  }
  getArchive(page: number, posts: number, sort: string, order: string): Observable<FeedResponse> {
    this.loading = true;
    return this.http.get<FeedResponse>(`${this.feedApiUrl}/archive?page=${page}&posts=${posts}&sort=${sort}&order=${order}`)
      .pipe(
        catchError(this.handleError<FeedResponse>('getArchive', {} as FeedResponse))
      );
  }
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      console.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
