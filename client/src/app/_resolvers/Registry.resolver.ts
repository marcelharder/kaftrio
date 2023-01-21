import {Injectable} from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';
import { RegistryService } from '../_services/registry.service';
import { Registry } from '../_models/registry';

@Injectable()

export class RegistryResolver implements Resolve<Registry[]> {
    pageNumber = 1;
    pageSize = 12;
    
    constructor(private regservice: RegistryService,
        private router: Router,
        private alertify: ToastrService) {}
    resolve(route: ActivatedRouteSnapshot): Observable<Registry[]> {
         return this.regservice.getRegistries(this.pageNumber, this.pageSize).pipe(catchError(error => {
            this.alertify.error('Problem retrieving data');
            this.router.navigate(['/home']);
            return of(null);
        }));







    }
}
