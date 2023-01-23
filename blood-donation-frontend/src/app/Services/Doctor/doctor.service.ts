import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})


export class DoctorService {

  
  constructor(private http:HttpClient) { }

  GetById(id : any) {
    const publicHttpHeaders= {
      //'Authorization': 'Bearer ' + localStorage.getItem('token')
        headers: new HttpHeaders({'content-type':'application/json',
        'Authorization': 'Bearer ' + localStorage.getItem('jwt')}) 
        
      };
    return this.http.get("https://localhost:7118/api/Doctor/" + id,publicHttpHeaders)
}
}
