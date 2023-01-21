import { Component, Input, OnInit } from '@angular/core';
import { ChartType, ChartOptions } from 'chart.js';
import { SingleDataSet, Label, monkeyPatchChartJsLegend, monkeyPatchChartJsTooltip } from 'ng2-charts';
import { GraphModel } from 'src/app/_models/GraphModel';


@Component({
  selector: 'app-age',
  templateUrl: './age.component.html',
  styleUrls: ['./age.component.css']
})
export class AgeComponent implements OnInit {
  @Input() gm: GraphModel = {
    caption: '',
    dataXas: [],
    dataYas: []
  };
  data: any = [];
  title = "";

  ngOnInit() {
    var num: number = 0;
    var i: number;
    var help: Array<any> = [];
    for (i = num; i < this.gm.dataXas.length; i++) { help.push([this.gm.dataXas[i], this.gm.dataYas[i]]); }
    debugger;
    this.data = help;
    this.title = this.gm.caption;

  }

  //public pieChartLabels:string[]=['Female','Male'];
  //public pieChartData: any =[51,30];

  public pieChartLabels: string[] = this.gm.dataXas;
  public pieChartData: number[] = this.gm.dataYas;

  //public pieChartData: SingleDataSet = this.gm.dataYas;


  public pieChartOptions: ChartOptions = { responsive: true, };
  //public pieChartLabels: Label[] = [['SciFi'], ['Drama'], 'Comedy'];
  //public pieChartData: SingleDataSet = [30, 50, 20];
  public pieChartType: ChartType = 'bar';
  public pieChartLegend = true;
  public pieChartPlugins: any = [];
  constructor() {
    monkeyPatchChartJsTooltip();
    monkeyPatchChartJsLegend();
  }


}
