import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/app/environments/environment';
import { LoginUser } from 'src/app/Models/LoginUser';
import { User } from 'src/app/Models/User';

@Injectable({
  providedIn: 'root'
  
})
export class AuthService {
  
  tokenResp:any
  baseApiUrl: string = environment.baseApiUrl
  constructor(private http:HttpClient) { }

  GetRoleByToken(token: any) {
    let _token = token.split('.')[1];
    this.tokenResp = JSON.parse(atob(_token));
    console.log(this.tokenResp.role);
    return this.tokenResp.role;
  }
  
  registerPatient(user: any){
    console.log("Am ajuns in service auth.service.ts")
    // exemplu:  return this.http.get(this.baseApiUrl + "/api/Auth/Patients");
    console.log(user)
    // return this.http.register....

  }
  

  editPacient(){}
  // registerUser(user: any){
  //   console.log("Am ajuns in service auth.service.ts")
  //   // exemplu:  return this.http.get("https://localhost:7118/api/Patients");
  //   console.log(user)
  //   // return this.http.register....
  //   //return this.http.post("https://localhost:7118/api/Auth/Register");
  //   const headers = { 'content-type': 'application/json'}  
  //   const body=JSON.stringify(user);
  //   console.log(body)
  //   return this.http.post('https://localhost:7118/api/Auth/Register', body)
  // }
  registerUser(user: any) : Observable<any>{
    console.log("Am ajuns in service auth.service.ts")
    // exemplu:  return this.http.get("https://localhost:7118/api/Patients");
    console.log(user)
    // return this.http.register....
    //return this.http.post("https://localhost:7118/api/Auth/Register");
    return this.http.post<any>(`${this.baseApiUrl}/api/Auth/Register`, user
  );}
  loginUser(user: any){
    console.log("Am ajuns in service auth.service.ts")
    // exemplu:  return this.http.get("https://localhost:7118/api/Patients");
    console.log(user)
    return this.http.post<any>(`${this.baseApiUrl}/api/Auth/Login`, user)
    // return this.http.register....

  }
}
  