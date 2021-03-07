import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { NorrkopingNewspapersComponent } from './norrkoping-newspapers/norrkoping-newspapers.component';
import { NewsFlowComponent } from './news-flow/news-flow.component';
import { ExpressenComponent } from './expressen/expressen.component';
import { SvdComponent } from './svd/svd.component';

const routes: Routes = [
  { path: '', component: NewsFlowComponent },
  { path: 'norrkoping-newspapers', component: NorrkopingNewspapersComponent },
  { path: 'expressen', component: ExpressenComponent },
  { path: 'svd', component: SvdComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
