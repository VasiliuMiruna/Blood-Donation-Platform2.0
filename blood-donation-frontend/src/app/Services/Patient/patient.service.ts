import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Patient } from 'src/app/Models/Patient';
import { User } from 'src/app/Models/User';


@Injectable({
  providedIn: 'root'
})
export class PatientService {

  user = new User()
  private publicHttpHeaders= {
  //'Authorization': 'Bearer ' + localStorage.getItem('token')
    headers: new HttpHeaders({'content-type':'application/json',
    'Authorization': 'Bearer ' + localStorage.getItem('jwt')}) 
    
  };
  
  constructor(private http:HttpClient) {

   }

   setUser(_user:User) {
      this.user = _user;
      console.log("Suntem ins set")
      console.log(this.user)


   }
   GetMyself(){
    return this.user;
   }
  //pot avea orice nume
  GetPatientById(){
    return this.http.get("https://localhost:7118/api/Patients/",this.publicHttpHeaders);
  }

  GetById(id : any) {
      return this.http.get("https://localhost:7118/api/Patients/" + id,this.publicHttpHeaders)
  }
  UpdateById(id : any, value : Patient) {
    return this.http.put("https://localhost:7118/api/Patients/" + id, value, this.publicHttpHeaders)
    .subscribe();
    
  }
  DeleteById(id: any) {
    return this.http.delete("https://localhost:7118/api/Patients/" + id, this.publicHttpHeaders)
  
  }
  // addPatient(){
  //   return this.http.post("https://localhost:7038/api/Patients")
  // }

  /*
  Pagina de Login
  login(){
    this.loading = true
    this.setUser()
    console.log("intra aici pacient")
    console.log(this.userDto)
  //  window.location.href = "/pacient"
    this._service.loginPatient(this.userDto).subscribe((response: any) => {
      this.loading = false
      console.log("doLogin")
      console.log(response);

      if(response == null){
      
          this.msg ="Contul nu este valid!"

      }
      if (response && response.jwt) {
        console.log("intra in if")
        localStorage.setItem('token', response.jwt)
        localStorage.setItem('role', response.patient.role)
        localStorage.setItem('patient', JSON.stringify(response.patient))
        localStorage.setItem('cnp', response.patient.cnp) 
        if(localStorage.getItem("role") == "PACIENT"){
          window.location.href = "/pacient/home"
        }else{
          this._service.logoutUser()
          window.location.href = "/dashboard"

        }
        console.log("dupa token")
      }
     
    })

  }
  }


  */

}
