import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardDoctorComponent } from './Pages/dashboard-doctor/dashboard-doctor.component';
import { RegisterComponent } from './Pages/register/register.component';
import { LoginComponent } from './Pages/login/login.component';

const routes: Routes = [{
  path:"Doctor",
  component: DashboardDoctorComponent
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
