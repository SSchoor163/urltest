import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse, HttpErrorResponse } from "@angular/common/http";
import { Observable, BehaviorSubject, throwError } from "rxjs";
import { map, catchError } from "rxjs/operators";
import {Company} from '../interfaces/company';
import { environment } from '../../environments/environment';



@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  constructor(private http: HttpClient) { 
    
  }
  APIEndPoint = environment.APIEndpoint+"/api/company/";
  
  comapny:Company;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': this.APIEndPoint
  })};

  getAll(): Observable<Company[]>{
    return this.http.get<Company[]>(this.APIEndPoint);
  }
  get(id:number){
    return this.http.get<Company>(this.APIEndPoint+id, this.httpOptions);
  }
  post(company:Company): Observable<Company>{
    return this.http.post<Company>(this.APIEndPoint, company);
  }
  delete(id:number):Observable<{}>{
    return this.http.delete(this.APIEndPoint+id);
  }
  update(company:Company, id:number):Observable<Company> {
    return this.http.put<Company>(this.APIEndPoint+ id, company);
  }
  
}
