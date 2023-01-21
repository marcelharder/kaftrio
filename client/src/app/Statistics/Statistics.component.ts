import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-Statistics',
  templateUrl: './Statistics.component.html',
  styleUrls: ['./Statistics.component.css']
})
export class StatisticsComponent implements OnInit {
  reqSampleSize = 50;
  noComplRecords = 30;
  noRecords = 35;

  noSingleMutation = 20;
  noDoubleMutation = 15;

  percSingle = (this.noSingleMutation/this.noRecords) * 100;
  percDouble = (this.noDoubleMutation/this.noRecords) * 100;

  constructor() { }

  ngOnInit() {
  }

}
