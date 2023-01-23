import { Component } from '@angular/core';
import { PatientService } from 'src/app/Services/Patient/patient.service';
import { DoctorService } from 'src/app/Services/Doctor/doctor.service';
import { Routes, RouterModule, TitleStrategy } from '@angular/router';

@Component({
  selector: 'app-dashboard-doctor',
  templateUrl: './dashboard-doctor.component.html',
  styleUrls: ['./dashboard-doctor.component.css']
})

// const routes: Routes = [
//   { path: '', redirectTo: 'Doctor', pathMatch: 'full' },
//   // { path: 'Patients', component: DashboardDoctorComponent },
//   // { path: 'add', component: CreatePatientComponent },
// ];
export class DashboardDoctorComponent {
  //declar variabilele
  patientList : any
  patient1 : any
  ok : boolean = false
  constructor(private patientService : PatientService, private doctorService:DoctorService) {}

//tot ce e aici se pune cand se incarca pg
ngOnInit() {

  this.getAllPatients()

}

  getAllPatients(){
    //punem subscribe ca e de tip return 
    this.patientService.GetPatientById().subscribe((res)=> {
      this.patientList = res

      console.log(this.patientList)
    })
  }


  getPatientById(id : any) {
      console.log(id)
      this.patientService.GetById(id).subscribe((res)=> {
        console.log(res)
    this.patient1 = res
      this.ok = true
      console.log()
      //console.log(JSON.parse(this.patient).lastName)

    })
  }

    
  deletePatientById(id : any) {
      
    this.patientService.DeleteById(id).subscribe((res)=> {
    //this.patient = JSON.stringify(res)
    this.ok = true
    console.log("s-a sters pacientul")
    //console.log(JSON.parse(this.patient).lastName)

  })
  }

  getDoctorById(id:any) {
    this.doctorService.GetById(id).subscribe(()=> {
      this.ok = true
    })
  }
}

