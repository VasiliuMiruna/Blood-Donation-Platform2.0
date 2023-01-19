import { Component } from '@angular/core';
import { PatientService } from 'src/app/Services/Patient/patient.service';

@Component({
  selector: 'app-dashboard-doctor',
  templateUrl: './dashboard-doctor.component.html',
  styleUrls: ['./dashboard-doctor.component.css']
})
export class DashboardDoctorComponent {
  //declar variabilele
  patientList : any
  patient : any
  ok : boolean = false
  constructor(private patientService : PatientService) {}

//tot ce e aici se pune cand se incarca pg
ngOnInit() {

  this.getAllPatients()

}

  getAllPatients(){
    //punem subscribe ca e de tip return 
    this.patientService.GetPatient().subscribe((res)=> {
      this.patientList = res

      console.log(this.patientList)
    })
  }


  getPatientById(id : any) {
      
      this.patientService.GetById(id).subscribe((res)=> {
      this.patient = JSON.stringify(res)
      this.ok = true
      console.log(this.patient)

    })
  }
}
