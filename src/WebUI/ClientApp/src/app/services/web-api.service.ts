import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, catchError, Observable, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class WebApiService {
  constructor(private http: HttpClient) {}
  get<T>(url: string) {
    const headers = this.setHeaders();
    return this.http.get(environment.apiUrl + url, { headers }).pipe(
      map((response) => response as T),
      catchError(this.handleError)
    );
  }
  post<T>(url: string, data: any) {
    const headers = this.setHeaders();
    return this.http.post(environment.apiUrl + url, data, { headers }).pipe(
      map((response) => response as T),
      catchError(this.handleError)
    );
  }
  put<T>(url: string, data: any) {
    const headers = this.setHeaders();
    return this.http.put(environment.apiUrl + url, data, { headers }).pipe(
      map((response) => response as T),
      catchError(this.handleError)
    );
  }

  setHeaders(content: any = 'application/json', auth: any = '') {
    let headers = new HttpHeaders();

    headers.set('Access-Control-Allow-Origin', '*');
    headers.set(
      'Access-Control-Allow-Headers',
      'Access-Control-Allow-Headers, Content-Type, Authorization'
    );
    headers.set('Access-Control-Allow-Methods', '*');
    headers.set('Content-Type', 'application/json');

    if (auth) {
      headers = headers.set('Content-type', content).set('Authorization', auth);
    } else {
      headers = headers.set('Content-type', content);
    }
    return headers;
  }

  // Error handling
  handleError(error: any) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    //window.alert(errorMessage);
    return throwError(() => {
      return errorMessage;
    });
  }
}
