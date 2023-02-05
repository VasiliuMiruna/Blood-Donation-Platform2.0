import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardDoctorComponent } from './Pages/dashboard-doctor/dashboard-doctor.component';
import { DashboardDonorComponent } from './Pages/dashboard-donor/dashboard-donor.component';
import { RegisterComponent } from './Pages/register/register.component';
import { LoginComponent } from './Pages/login/login.component';
import { DashboardPatientComponent } from './Pages/dashboard-patient/dashboard-patient.component';
import { AuthGuard } from './Guard/Auth/auth.guard';
import { DashboardAdminComponent } from './Pages/dashboard-admin/dashboard-admin.component';

const routes: Routes = [{
  path:"Doctor/:id",
  component: DashboardDoctorComponent,
  canActivate : [AuthGuard]
},
{
  //doamne a mers
  path:"Patient/:id",
  component: DashboardPatientComponent,
  canActivate : [AuthGuard]

},
{
path:"Donor/:id",
component: DashboardDonorComponent,
canActivate : [AuthGuard]
},
{
path:"Admin",
component: DashboardAdminComponent,
canActivate : [AuthGuard]
},
{
  path:"register",
  component: RegisterComponent
},
{
  path:"login",
  component: LoginComponent
},
{
  path:"", 
  redirectTo: "/login",
  pathMatch: "full"
}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
