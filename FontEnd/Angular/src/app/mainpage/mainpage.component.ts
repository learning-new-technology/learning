import { Component, OnInit } from '@angular/core';

import { ReSorts } from './mainpage';
import { MainPageService } from './mainpage.service';

@Component({
  selector: 'app-mainpage',
  templateUrl: './mainpage.component.html',
  providers: [MainPageService],
  styleUrls: ['./mainpage.component.scss']
})
export class MainpageComponent implements OnInit {
  resorts: ReSorts[];

  constructor(
    private mainpageService: MainPageService
  ) { }

  ngOnInit() {
    this.getResorts();
  }

  /** GET ReSorts */
  getResorts(): void {
    this.mainpageService.getResorts().subscribe(resorts => (
      // this.resorts = resorts
      console.log(resorts)
    ));
  }
}
