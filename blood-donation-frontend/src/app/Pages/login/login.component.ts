import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { LoginUser } from 'src/app/Models/LoginUser';
import { Patient } from 'src/app/Models/Patient';
import { AuthService } from 'src/app/Services/Auth/auth.service';
import { Router } from "@angular/router";

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
  constructor(private router: Router, private fb: FormBuilder,private authService: AuthService){}
  
  onSubmit(){
    this.loginUser.Password = this.formUser.value.password?.toString() ?? ""
    this.loginUser.Email = this.formUser.value.email?.toString() ?? ""
    console.log("S-a conectat in login.component.ts")
    console.log(this.contactForm)
    this.authService.loginUser(this.loginUser).subscribe(data=>console.log(data),response => {
      const token = (<any>response).token;
      localStorage.setItem("jwt", token);
      this.invalidLogin = false;
      this.router.navigate(["/Doctor"]);
    });
    
  }
}

