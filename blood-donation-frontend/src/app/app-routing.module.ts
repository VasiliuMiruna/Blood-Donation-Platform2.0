import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardDoctorComponent } from './Pages/dashboard-doctor/dashboard-doctor.component';
import { RegisterComponent } from './Pages/register/register.component';
import { LoginComponent } from './Pages/login/login.component';
import { DashboardPatientComponent } from './Pages/dashboard-patient/dashboard-patient.component';
import { AuthGuard } from './Guard/Auth/auth.guard';

const routes: Routes = [{
  path:"Doctor",
  component: DashboardDoctorComponent,
  canActivate : [AuthGuard]
},
{
  path:"Patient",
  component: DashboardPatientComponent,
  //canActivate : [AuthGuard]

},
{
path:"Donor",
component: DashboardDoctorComponent,
//canActivate : [AuthGuard]
},
{
path:"Admin",
component: DashboardDoctorComponent,
//canActivate : [AuthGuard]
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
