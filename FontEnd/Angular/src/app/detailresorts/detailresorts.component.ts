import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { map, switchMap  } from 'rxjs/operators';

import { DetailResorts } from './detailresorts';
import { DetailResortsService } from './detailresorts.service';

@Component({
  selector: 'app-detailresorts',
  templateUrl: './detailresorts.component.html',
  providers: [DetailResortsService],
  styleUrls: ['./detailresorts.component.scss']
})
export class DetailresortsComponent implements OnInit {
  resorts: DetailResorts;
  paramId: number;

  constructor(
    private route: ActivatedRoute,
    private detailResortsService: DetailResortsService,
  ) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.paramId = +params.id; // (+) converts string 'id' to a number
    });
    this.getDetailResorts(this.paramId);
  }

  /** GET Detail ReSorts */
  getDetailResorts(id): void {
    this.detailResortsService.getDetailResorts(id).subscribe(resorts => (
      this.resorts = resorts
    ));
  }
}
