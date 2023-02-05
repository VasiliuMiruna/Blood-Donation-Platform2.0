import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { DashboardDoctorComponent } from './Pages/dashboard-doctor/dashboard-doctor.component';
import { RegisterComponent } from './Pages/register/register.component';
import { ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './Pages/login/login.component';
import { DashboardPatientComponent } from './Pages/dashboard-patient/dashboard-patient.component';
import { DashboardDonorComponent } from './Pages/dashboard-donor/dashboard-donor.component';
import { DashboardAdminComponent } from './Pages/dashboard-admin/dashboard-admin.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardDoctorComponent,
    RegisterComponent,
    LoginComponent,
    DashboardPatientComponent,
    DashboardDonorComponent,
    DashboardAdminComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
