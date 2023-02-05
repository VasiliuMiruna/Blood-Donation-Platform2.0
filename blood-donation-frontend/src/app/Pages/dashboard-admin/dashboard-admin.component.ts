import { Component } from '@angular/core';
import { PatientService } from 'src/app/Services/Patient/patient.service';
import { DoctorService } from 'src/app/Services/Doctor/doctor.service';
import { Routes, RouterModule, TitleStrategy } from '@angular/router';

@Component({
  selector: 'app-dashboard-admin',
  templateUrl: './dashboard-admin.component.html',
  styleUrls: ['./dashboard-admin.component.css']
})

export class DashboardAdminComponent {
  doctorList : any
  doctor1 : any
  ok : boolean = false
  patientList : any


}
