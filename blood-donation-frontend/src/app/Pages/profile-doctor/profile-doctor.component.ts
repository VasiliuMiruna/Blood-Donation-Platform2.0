import { Component } from '@angular/core';
import { Routes, Router, RouterModule } from "@angular/router";
import { DoctorService } from 'src/app/Services/Doctor/doctor.service';
import { DashboardDoctorComponent } from '../dashboard-doctor/dashboard-doctor.component';




@Component({
  selector: 'app-profile-doctor',
  templateUrl: './profile-doctor.component.html',
  styleUrls: ['./profile-doctor.component.css']
})
export class ProfileDoctorComponent {

  ngOnInit() {
  }
}
