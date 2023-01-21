import { Component, Input, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { GraphModel } from 'src/app/_models/GraphModel';
import { GraphService } from 'src/app/_services/Graph.service';

@Component({
  selector: 'app-graph',
  templateUrl: './graph.component.html',
  styleUrls: ['./graph.component.css']
})
export class GraphComponent implements OnInit {
  showGraphNo = 0;
  gm: GraphModel = { dataXas: [], dataYas: [], caption: "" };
  currentUserId = 0;
  selectedHospital = 0;

  constructor(private alertify:ToastrService, private graph: GraphService) { }

  ngOnInit() {
  }

  getFunction01(){this.alertify.info("functie 1");
  this.graph.getAge(this.currentUserId, this.selectedHospital).subscribe(
    (next) => { this.gm = next; this.showGraphNo = 3; },
    (error) => {this.alertify.error(error)});}
  
  
  
  
  
  getFunction02(){this.alertify.info("functie 2")}
  getFunction03(){this.alertify.info("functie 3")}
  getFunction04(){this.alertify.info("functie 4")}
  getFunction05(){this.alertify.info("functie 5")}
  getFunction06(){this.alertify.info("functie 6")}

}
