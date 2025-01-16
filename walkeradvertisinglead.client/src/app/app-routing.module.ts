import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { LeadDetailsComponent } from './components/lead-details/lead-details.component';

const routes: Routes = [
  { path: '', component: DashboardComponent },
  //{ path: '', redirectTo: 'dashboard', pathMatch: 'full' }, // Default route
  //{ path: 'dashboard', component: DashboardComponent },    // Dashboard route
  //{ path: '**', redirectTo: 'dashboard' },                 // Wildcard route
  { path: 'lead-details/:id', component: LeadDetailsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
