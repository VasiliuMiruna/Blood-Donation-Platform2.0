import { Component, OnDestroy, OnInit } from '@angular/core';
import { Patient } from 'src/app/Models/Patient';
import { PatientService } from 'src/app/Services/Patient/patient.service';
import { Routes, Router, RouterModule, ActivatedRoute } from "@angular/router";
import { NgModule } from '@angular/core';
import { map, Subscription } from 'rxjs';


const routes: Routes = [
  { path: '', redirectTo: 'Patient/:id', pathMatch: 'full' }

];

@Component({
  selector: 'app-dashboard-patient',
  templateUrl: './dashboard-patient.component.html',
  styleUrls: ['./dashboard-patient.component.css']
})
export class DashboardPatientComponent implements OnInit, OnDestroy{
  patientList : any
  user : any
  patient : any = new Patient()
  patientId : any
  ok : boolean
  private sub : Subscription;
  constructor(private patientService : PatientService, private activateRoute : ActivatedRoute) {}
  

  ngOnInit() {
    this.sub = this.activateRoute.params.subscribe(params => {
      this.patientId = params['id'];
      console.log(this.patientId);
      console.log(this.patientService.GetById(this.patientId));
      this.patientService.GetById(this.patientId).pipe(
        map((patient:any) => this.patient = patient)
      ).subscribe();
    });
  //   this.getMyself()
  // this.getPatientById(localStorage.getItem("id"));
  }
  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  getPatientById(id : any) {
    console.log(id)
    this.patientService.GetById(id).subscribe((data) => {
      this.patient = data;})
    this.patientId = this.patient.id
    console.log(this.patientId)
    //console.log(JSON.parse(this.patient).lastName)

  
  }

  getMyself(){
  
    console.log("Ajungem in getMyself")
    this.user = this.patientService.GetMyself();
      
      console.log(this.user)
  }
}
