import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { ReSorts } from './mainpage';
import { httpOptions } from '../config/constants';
import { APIReSorts } from '../config/apis';
import { HttpErrorHandler, HandleError } from '../http-error-handler.service';

@Injectable()
export class MainPageService {
  private handleError: HandleError;

  constructor(
    private http: HttpClient,
    httpErrorHandler: HttpErrorHandler
  ) {
    this.handleError = httpErrorHandler.createHandleError('MainPageService');
  }

  /** GET ReSorts from the server */
  getResorts(): Observable<ReSorts[]> {
    // const option = { params: new HttpParams().set('limit', 12) || { }};
    return this.http.get<ReSorts[]>(APIReSorts)
      .pipe(
        catchError(this.handleError('getResorts', []))
      );
  }
}
