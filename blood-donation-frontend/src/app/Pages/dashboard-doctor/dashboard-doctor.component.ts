import { Component, ViewChild } from '@angular/core';
import { PatientService } from 'src/app/Services/Patient/patient.service';
import { DoctorService } from 'src/app/Services/Doctor/doctor.service';
import { Routes, RouterModule, TitleStrategy } from '@angular/router';
import { NgForm } from '@angular/forms';
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
  editMode:boolean = false
  currentPatientId : string
  @ViewChild('patientsForm') form: NgForm;
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
  onPatientCreate(patients: {id: any, firstName:string, lastName:string, age:number, bloodType:string, gender:string,phoneNumber:string}){
    patients.id = this.currentPatientId;
    if(this.editMode)
      this.patientService.UpdateById(this.currentPatientId, patients)
    else
      this.getAllPatients();
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
  onEditClicked(id : any) {
      //get the patient by id
      this.currentPatientId = id;
      let currentPatient = this.patientList.find((p: { id: any; }) => {return p.id == id})
      //console.log(this.form);
      //populate a form with the patient details
      this.form.setValue({
        firstName: currentPatient.firstName,
        lastName: currentPatient.lastName,
        age: currentPatient.age,
        bloodType: currentPatient.bloodType,
        gender: currentPatient.gender,
        phoneNumber:currentPatient.phoneNumber
      });
      //have a button
      this.editMode = true;
      // this.patientService.UpdateById(this.currentPatientId);

  }
    
  deletePatientById(id : any) {
      
    this.patientService.DeleteById(id).subscribe((res)=> {
    //this.patient = JSON.stringify(res)
    this.ok = true
    console.log("s-a sters pacientul")
    //console.log(JSON.parse(this.patient).lastName)
    //refresh
    this.ngOnInit();

  })
  }

  getDoctorById(id:any) {
    this.doctorService.GetById(id).subscribe(()=> {
      this.ok = true
    })
  }
}

