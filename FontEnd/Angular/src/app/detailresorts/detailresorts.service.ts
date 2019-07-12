import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { DetailResorts } from './detailresorts';
import { httpOptions } from '../config/constants';
import { APIDetailResorts, APIUpdateResorts } from '../config/apis';
import { HttpErrorHandler, HandleError } from '../http-error-handler.service';

@Injectable()
export class DetailResortsService {
  private handleError: HandleError;

  constructor(
    private http: HttpClient,
    httpErrorHandler: HttpErrorHandler
  ) {
    this.handleError = httpErrorHandler.createHandleError('DetailResortsService');
  }

  /** GET ReSorts from the server */
  getDetailResorts(idResorts): Observable<DetailResorts[]> {
    // const option = { params: new HttpParams().set('id', idResorts) || { }};
    return this.http.get<DetailResorts[]>(APIDetailResorts.replace('{0}', idResorts))
      .pipe(
        catchError(this.handleError('getResorts', []))
      );
  }

  postDetailResorts(resorts: DetailResorts): Observable<bool> {
    // Call API aupdate resorts
    return this.http.post<bool>(APIUpdateResorts, resorts, httpOptions)
      .pipe(
        catchError(this.handleError('postDetailResorts', []))
      );
  }
}
