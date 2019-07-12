import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

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
    private mainpageService: MainPageService,
    private router: Router,
  ) { }

  ngOnInit() {
    this.getResorts();
  }

  /** GET ReSorts */
  getResorts(): void {
    this.mainpageService.getResorts().subscribe(resorts => (
      this.resorts = resorts
    ));
  }

  goToDetail(id: number): void {
    this.router.navigate(['/resorts', id]);
  }
}
