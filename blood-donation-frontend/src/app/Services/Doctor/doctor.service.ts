import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { User } from 'src/app/Models/User';

@Injectable({
  providedIn: 'root'
})


export class DoctorService {
  user = new User()
  private publicHttpHeaders= {
    //'Authorization': 'Bearer ' + localStorage.getItem('token')
      headers: new HttpHeaders({'content-type':'application/json',
      'Authorization': 'Bearer ' + localStorage.getItem('jwt')}) 
      
    };
  
  constructor(private http:HttpClient) { }

  GetDoctorById(){
    return this.http.get("https://localhost:7118/api/Doctors/",this.publicHttpHeaders);
  }

  GetById(id : any){
    
    return this.http.get("https://localhost:7118/api/Doctors/" + id,this.publicHttpHeaders);
    
}
  GetByUserId(userId : any) {
    return this.http.get("https://localhost:7118/api/Doctors/user/" + userId,this.publicHttpHeaders);
  }

}
