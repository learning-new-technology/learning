import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { map, switchMap  } from 'rxjs/operators';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';

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
  profileForm = this.fb.group({
    name: ['', Validators.required],
    address: ['', Validators.required],
    price: [0, Validators.required],
  });

  constructor(
    private route: ActivatedRoute,
    private detailResortsService: DetailResortsService,
    private fb: FormBuilder,
    private router: Router,
  ) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.paramId = +params.id; // (+) converts string 'id' to a number
    });
    this.getDetailResorts(this.paramId);
  }

  /** GET detail ReSorts */
  getDetailResorts(id): void {
    this.detailResortsService.getDetailResorts(id).subscribe(resorts => {
      this.resorts = resorts;
      this.profileForm.setValue({
        name: resorts.name,
        address: resorts.address,
        price: resorts.price,
      });
    });
  }

  /** Event update Resorts */
  onSubmit() {
    // TODO: Use EventEmitter with form value
    this.mapProfileFormToResorts();
    this.detailResortsService.postDetailResorts(this.resorts).subscribe(result => {
      if (result === true) {
        this.router.navigate(['/']);
      } else {
        alert('ERROR');
      }
    });
  }

  /** POST update ReSorts */

  /** Update value from profileForm to resorts */
  mapProfileFormToResorts() {
    this.resorts.name = this.profileForm.value.name;
    this.resorts.address = this.profileForm.value.address;
    this.resorts.price = this.profileForm.value.price;
  }
}
