import { Component, OnDestroy, OnInit } from '@angular/core';
import { Routes, Router, RouterModule, ActivatedRoute } from "@angular/router";
import { map, Subscription } from 'rxjs';
import { User } from 'src/app/Models/User';
import { DoctorService } from 'src/app/Services/Doctor/doctor.service';
import { DashboardDoctorComponent } from '../dashboard-doctor/dashboard-doctor.component';




@Component({
  selector: 'app-profile-doctor',
  templateUrl: './profile-doctor.component.html',
  styleUrls: ['./profile-doctor.component.css']
})
export class ProfileDoctorComponent implements OnInit, OnDestroy{
  doctorID: any;
  private sub: Subscription;
  doctor: any;
  doctorList: any;
  ok: boolean;
  constructor(private router: Router, private doctorService: DoctorService, private activateRoute: ActivatedRoute) {}
  

  ngOnInit() {
    this.getAllDoctors();
    this.sub = this.activateRoute.params.subscribe(params => {
      this.doctorID = params['id'];
    });
    this.getDoctorByUserId(this.doctorID);
    console.log(this.doctor);
  }

  getAllDoctors(){
    //punem subscribe ca e de tip return 
    this.doctorService.GetDoctorById().subscribe((res)=> {
      this.doctorList = res

      console.log(this.doctorList)
    })
  }

  getDoctorByUserId(id : any) {
    console.log(id)
    this.doctorService.GetByUserId(id).subscribe((res)=> {
      console.log(res)
    this.doctor = res
    this.ok = true
    console.log()
    //console.log(JSON.parse(this.patient).lastName)

  })
}

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}
