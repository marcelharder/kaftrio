import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { PaginatedResult } from '../_models/pagination';
import { Registry } from '../_models/registry';

@Injectable({
  providedIn: 'root'
})
export class RegistryService {
  baseUrl = environment.apiUrl;

constructor( private http: HttpClient) { }



getRegistries(page?: number, itemsPerPage?: number): Observable<PaginatedResult<Registry[]>> {
  const paginatedResult: PaginatedResult<Registry[]> = new PaginatedResult<Registry[]>();

  let params = new HttpParams();

  if (page != null && itemsPerPage != null) {
    params = params.append('pageNumber', page);
    params = params.append('pageSize', itemsPerPage);
  }

  return this.http.get<Registry[]>(this.baseUrl + 'getListOfRegistries', { observe: 'response', params })
    .pipe(
      map((response) => {
        if(response.body !== null){
        paginatedResult.result = response.body;
         if (response.headers.get('Pagination') !== null) {
          paginatedResult.pagination = JSON.parse(response.headers.get('Pagination')!);
        }} 
        return paginatedResult;
      })
    );

    
    
}


getRegistry(id: number){return this.http.get<Registry>(this.baseUrl + 'getRegistry/' + id)};
addRegistry(){return this.http.post<Registry>(this.baseUrl + 'addRegistry', null)};
deleteRegistry(id: number){return this.http.delete<string>(this.baseUrl + 'deleteRegistry/' + id,{ responseType: 'text' as 'json' })}
updateRegistry(record: Registry){return this.http.put<string>(this.baseUrl + 'updateRegistry', record, {responseType: 'text' as 'json'})}


}



