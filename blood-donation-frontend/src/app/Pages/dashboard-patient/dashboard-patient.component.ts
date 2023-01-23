import { Component } from '@angular/core';
import { Patient } from 'src/app/Models/Patient';
import { PatientService } from 'src/app/Services/Patient/patient.service';

@Component({
  selector: 'app-dashboard-patient',
  templateUrl: './dashboard-patient.component.html',
  styleUrls: ['./dashboard-patient.component.css']
})
export class DashboardPatientComponent {
  patient : any
  constructor(private patientService : PatientService) {}

  ngOnInit() {

   // this.getMyself()
  

}

// getMyself(){
 
//   console.log("Ajungem in getMyself")
//   this.patientService.GetPatientById().subscribe((res)=> {
//     this.patient = res
//     console.log("here")
//     console.log(this.patient)
//   })
// }
}
