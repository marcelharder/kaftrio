import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DropItem } from '../_models/dropItem';
import { Registry } from '../_models/registry';
import { RegistryService } from '../_services/registry.service';

@Component({
  selector: 'app-RegistryDetails',
  templateUrl: './RegistryDetails.component.html',
  styleUrls: ['./RegistryDetails.component.css']
})
export class RegistryDetailsComponent implements OnInit {
  ageArray: Array<DropItem> = [];
  currentRegistry: Registry = {
    id: 0,
    age: 0,
    test01: '',
    test02: '',
    test03: '',
    test04: '',
    test05: '',
    test06: '',
    test07: '',
    test08: '',
    test09: '',
    test10: ''
  }

  constructor(
    private route: ActivatedRoute, 
    private reg: RegistryService,
    private alertify: ToastrService, 
    private router:Router) { }

  ngOnInit() {
    this.route.data.subscribe((data) => {
       this.currentRegistry = data.reg;});
    this.loadDrops();
  }

  updateRegistryDetails(){
    this.reg.updateRegistry(this.currentRegistry).subscribe((next)=>{
      this.router.navigate(['/listOfRegistries']);
      this.alertify.success(next);
    },(error)=>{this.alertify.error(error)})
   
  }

  deleteRegistry(){this.reg.deleteRegistry(this.currentRegistry.id).subscribe((next)=>{
    this.alertify.success("deleted");
    this.router.navigate(['/listOfRegistries']);
  })}
  
  cancel(){
    this.router.navigate(['/listOfRegistries']);
    this.alertify.warning("Cancelling")}

  loadDrops(){
    for (let x = 10; x < 90; x++) {
      let help = {"value":x,"description":x.toString()}
      this.ageArray.push(help);
    
    }
    
  }

}
