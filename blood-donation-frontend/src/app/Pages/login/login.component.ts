import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { LoginUser } from 'src/app/Models/LoginUser';
import { Patient } from 'src/app/Models/Patient';
import { AuthService } from 'src/app/Services/Auth/auth.service';
import { PatientService } from 'src/app/Services/Patient/patient.service';
import { RegisterComponent } from '../register/register.component';
import { Routes, Router, RouterModule } from "@angular/router";
import { NgModule } from '@angular/core';


const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'register', component: RegisterComponent },
];



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})


export class LoginComponent {

  
  invalidLogin?: boolean;
  formUser = this.fb.group({
    email: [''],
    password: ['']
  });
  loginUser = new LoginUser()
  contactForm = new FormGroup({
    
    email: new FormControl(),
    password: new FormControl(),
    
  })
  constructor(private patientService: PatientService, private router: Router, private fb: FormBuilder,private authService: AuthService){}
  

  

  onSubmit(){
    this.loginUser.Password = this.formUser.value.password?.toString() ?? ""
    this.loginUser.Email = this.formUser.value.email?.toString() ?? ""
    console.log("S-a conectat in login.component.ts")
    console.log(this.contactForm)
    this.authService.loginUser(this.loginUser).subscribe(response => {
      console.log(response)
      const token = (<any>response).accessToken;
      console.log(token)
      var currentRole = this.authService.GetRoleByToken(token);
      var currentId = this.authService.GetIdByToken(token);
      localStorage.setItem("jwt", token);
      console.log(currentRole);
      console.log(currentId);
      localStorage.setItem("role", currentRole);
      localStorage.setItem("id", currentId);
      //localStorage.setItem("role")
      // this.invalidLogin = false;
      if(currentRole == "Doctor")
        this.router.navigate(["/Doctor/" + currentId]);
      else if(currentRole == "Patient")
      {
        
      this.patientService.setUser(response);
      this.router.navigate(["/Patient/" + currentId]);
      }
      else if(currentRole == "Admin")
        this.router.navigate(["/Admin"]);
      else this.router.navigate(["/Donor"]);
    });
    
  }
}

