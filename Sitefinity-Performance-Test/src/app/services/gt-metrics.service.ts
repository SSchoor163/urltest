import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse, HttpErrorResponse } from "@angular/common/http";
import { Observable, BehaviorSubject, throwError } from "rxjs";
import { map, catchError } from "rxjs/operators";
import {GtMetrics} from '../interfaces/gt-metrics';
import {GtMetricsPost} from '../interfaces/gt-metrics-post'
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GtMetricsService {

  constructor(private http: HttpClient) { }
  APIEndPoint = environment.APIEndpoint+"/api/gtmetrics/";

  getAll(): Observable<GtMetrics[]>{
    return this.http.get<GtMetrics[]>(this.APIEndPoint);
  }
  get(id:number){
    return this.http.get<GtMetrics>(this.APIEndPoint+"/"+id);
  }
  post(post:GtMetricsPost): Observable<GtMetrics>{
    return this.http.post<GtMetrics>(this.APIEndPoint, post);
  }
  delete(id:number):Observable<{}>{
    return this.http.delete(this.APIEndPoint+'/'+id);
  }

}
