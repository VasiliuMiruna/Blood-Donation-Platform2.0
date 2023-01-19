import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Patient } from 'src/app/Models/Patient';
import { User } from 'src/app/Models/User';
import { AuthService } from 'src/app/Services/Auth/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  registerUser = this.formBuilder.group({
    firstname: [''],
    lastname:[''],
    email: [''],
    role: [''],
    password: ['']
  });
  user = new User()
  contactForm = new FormGroup({
    firstname: new FormControl(),
    lastname: new FormControl(),
    email: new FormControl(),
    role: new FormControl(),
    password: new FormControl()
    
  }) 
   
   constructor(private authService: AuthService, private formBuilder: FormBuilder){}
   ngOnInit() {
    
  }
  onSubmit(){
  
    this.user.FirstName = this.registerUser.value.firstname?.toString() ?? ""
    this.user.LastName = this.registerUser.value.lastname?.toString() ?? ""
    this.user.Password = this.registerUser.value.password?.toString() ?? ""
    this.user.Email = this.registerUser.value.email?.toString() ?? ""
    this.user.Role = this.registerUser.value.role?.toString() ?? ""
    console.log("S-a conectat in register.component.ts")
    console.log(this.contactForm)
    console.log(this.registerUser)
    this.authService.registerUser(this.user).subscribe(data => console.log(data))

    // if(this.contactForm.value.role == "pacient"){
    //   this.pacient.FirstName = this.contactForm.value.firstname
    //   this.pacient.LastName = this.contactForm.value.lastname
    //   this.authService.registerPatient(this.pacient)
    // }
    // else {
    //   console.log("La fel ca la pacient doar ca pe " + this.contactForm.value.role)
    // }
  }
}
