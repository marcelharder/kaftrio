import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-statisticsSummary',
  templateUrl: './statisticsSummary.component.html',
  styleUrls: ['./statisticsSummary.component.css']
})
export class StatisticsSummaryComponent implements OnInit {
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
