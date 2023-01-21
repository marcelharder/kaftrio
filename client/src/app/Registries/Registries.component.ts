import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { PaginatedResult, Pagination } from '../_models/pagination';
import { Registry } from '../_models/registry';
import { RegistryService } from '../_services/registry.service';

@Component({
  selector: 'app-Registries',
  templateUrl: './Registries.component.html',
  styleUrls: ['./Registries.component.css']
})
export class RegistriesComponent implements OnInit {

  listRegistries:Array<Registry> = [];
  pagination: Pagination;
 

  constructor(private route: ActivatedRoute, 
    private router: Router,
    private alertify: ToastrService,
    private reg: RegistryService) { }

  ngOnInit() {
    this.route.data.subscribe((data) => {
      this.listRegistries = data.regs.result;
      this.pagination = data.regs.pagination;
    
    
    })

  }

  editRegistry(id: number){this.router.navigate(['/registry/' + id]);}

  addRegistry(){
    this.reg.addRegistry().subscribe((next)=>{
      this.router.navigate(['/registry/' + next.id]);
    })
    
    
    
    
    
    this.alertify.success("Adding registry")}

  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.loadRegistries();
  }
  loadRegistries() {
    this.reg.getRegistries(this.pagination.currentPage, this.pagination.itemsPerPage)
    .subscribe((res: PaginatedResult<Registry[]>) => {
      this.listRegistries = res.result;
      this.pagination = res.pagination;
    }, error => console.log(error));

  }

}
