import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MainpageComponent } from './mainpage/mainpage.component';
import { DetailresortsComponent } from './detailresorts/detailresorts.component';

const routes: Routes = [
  {
    path: '',
    component: MainpageComponent
  },
  {
    path: 'resorts/:id',
    component: DetailresortsComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
