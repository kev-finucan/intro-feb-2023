import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './components/about/about.component';
import { CounterComponent } from './components/counter/counter.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ShoppingListComponent } from './components/shopping-list/shopping-list.component';

const routes: Routes = [
  {
    path: 'dashboard',
    component: DashboardComponent
  },
  {
    path: 'shopping',
    component: ShoppingListComponent
  },
  {
    path: 'about',
    component: AboutComponent
  },
  {
    path: 'counter',
    component: CounterComponent
  },
  {
    path: '**', // catch-all / default route if no other route match is found. Must be the last route
    redirectTo: 'dashboard' // Routing works like if/else when finding matches
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
