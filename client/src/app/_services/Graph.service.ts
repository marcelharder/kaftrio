import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { GraphModel } from '../_models/GraphModel';

@Injectable()
export class GraphService {
    baseUrl = environment.apiUrl;

    constructor(private http: HttpClient) { }

    getAge(userId: number,id: number) { return this.http.get<GraphModel>(this.baseUrl + 'ageGraph/' + userId + '/' + id); }
   
   
   // getBand(userId: number,id: number) { return this.http.get<GraphModel>(this.baseUrl + 'Graph/euroGraphPerHospital/' + userId + '/' + id); }
   // getPM(userId: number,id: number) {return this.http.get<GraphModel>(this.baseUrl + 'Graph/proceduresPerMonthGraphPerHospital/' + userId + '/' + id); }
   // getPY(userId: number,id: number) {return this.http.get<GraphModel>(this.baseUrl + 'Graph/proceduresPerYearGraphPerHospital/' + userId + '/' + id); }
}
